﻿using Login.Models;
using Login.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRpgEtec.Services.Usuarios
{
    public class UsuarioService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://xyz.somee.com/RpgApi/Usuarios";
        public UsuarioService()
        {
            _request = new Request();

        }

        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            //Registrar: rota para o método na API que registra o usuario
            string urlComplementar = "/Registrar";
            u.Id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, u);
            return u;
        }

        public async Task<Usuario> PostAutenticarUsuarioAsync(Usuario u)
        {
            //Autenticar: rota para o metodo na API que autentica com login e senha
            string urlComplementar = "/Autenticar";
            u = await _request.PostAsync(apiUrlBase + urlComplementar, u, string.Empty);
            return u;
        }
    }
}