﻿using Application.Interfaces;
using Application.Models.Request;
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
        private readonly AutenticacionServiceOptions _options;

        public AuthenticationService(IPassengerRepository passengerRepository ,IDriverRepository driverRepository, IOptions<AutenticacionServiceOptions> options)
        {
            _driverRepository = driverRepository;
            _passengerRepository = passengerRepository;
            _options = options.Value;
        }

        private List<Claim> claimsForToken;

        private User? ValidateUser(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            var driver = _driverRepository.GetDriverByName(authenticationRequest.UserName);
            var passenger = _passengerRepository.GetPassengerByName(authenticationRequest.UserName);

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

            return null;   
        }


        public string? Autenticar(AuthenticationRequest authenticationRequest)
        {
            //Paso 1: Validamos las credenciales
            var user = ValidateUser(authenticationRequest); 

            if (user == null)
            {
                //Saco la excepción porque en ConsultaAlumnos la api rompe si el usuario/contraseña es erroneo.
                //En ese caso devolvemos un 401 Unauthorizad o 403 Forbbiden.
                //throw new NotAllowedException("User authentication failed");
                return null;
            }

            //Paso 2: Crear el token
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey)); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            //CLAIMS            
            claimsForToken.Add(new Claim("sub", user.Id.ToString())); 
            claimsForToken.Add(new Claim("given_name", user.Name)); 

            var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
              _options.Issuer,
              _options.Audience,
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler() //Pasamos el token a string
                .WriteToken(jwtSecurityToken);

            return tokenToReturn.ToString();
        }



        public class AutenticacionServiceOptions
        {
            public const string AutenticacionService = "AutenticacionService";

            public string Issuer { get; set; }
            public string Audience { get; set; }
            public string SecretForKey { get; set; }
        }

    }
}
