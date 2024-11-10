using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Infraestructure.Services
{
    public class AuthenticationService : ICustomAuthenticationService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly AutenticacionServiceOptions _options;

        public AuthenticationService(IPassengerRepository passengerRepository ,IDriverRepository driverRepository,IAdminRepository adminRepository ,IOptions<AutenticacionServiceOptions> options)
        {
            _driverRepository = driverRepository;
            _passengerRepository = passengerRepository;
            _adminRepository = adminRepository;
            _options = options.Value;
        }

        private List<Claim> claimsForToken = new List<Claim>();

        private User? ValidateUser(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.Email) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            var driver = _driverRepository.GetDriverByEmail(authenticationRequest.Email);
            var passenger = _passengerRepository.GetPassengerByEmail(authenticationRequest.Email);
            var admin = _adminRepository.GetAdminByEmail(authenticationRequest.Email);

            claimsForToken = new List<Claim>();

            if (driver != null)
            {
                if (driver.Password == authenticationRequest.Password)
                {
                    claimsForToken.Add(new Claim(ClaimTypes.Role, "Driver"));
                    return driver; 
                }
            }

            if (passenger != null)
            {
                if (passenger.Password == authenticationRequest.Password)
                {
                    claimsForToken.Add(new Claim(ClaimTypes.Role, "Passenger"));
                    return passenger; 
                }
            }

            if (admin != null)
                if (admin.Password == authenticationRequest.Password)
                {
                    claimsForToken.Add(new Claim(ClaimTypes.Role, "Admin"));
                    return admin;
                }

            return null;   
        }

        public AuthenticationResponse? Autenticar(AuthenticationRequest authenticationRequest)
        {
            // Paso 1: Validamos las credenciales
            var user = ValidateUser(authenticationRequest);

            if (user == null)
            {
                return null;
            }

            // Paso 2: Crear el token
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            // CLAIMS            
            claimsForToken.Add(new Claim("sub", user.Id.ToString()));
            claimsForToken.Add(new Claim("given_name", user.Name));

            var jwtSecurityToken = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                credentials
            );

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            // Paso 3: Crear el objeto de respuesta
            var response = new AuthenticationResponse
            {
                Token = tokenToReturn,
                Id = user.Id,
                Role = claimsForToken.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? ""
            };

            return response;
        }

        public class AutenticacionServiceOptions
        {
            public const string AutenticacionService = "AutenticacionService";
            public string Issuer { get; set; } = string.Empty;
            public string Audience { get; set; } = string.Empty;
            public string SecretForKey { get; set; } = string.Empty;
        }
    }
}