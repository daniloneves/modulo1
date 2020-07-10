﻿using System;
using System.Collections.Generic;
using System.Text;
using Modulo1.Dto;

namespace Modulo1.Service
{
    public class OportunidadeService
    {
        public Oportunidade Salvar(string nome, string salario)
        {
            Oportunidade oportunidade = new Oportunidade();
            oportunidade.Nome = nome;
            oportunidade.Salario = salario;

            return oportunidade;
        }

        public Oportunidade AtribuirCandidatoAprovado(Oportunidade oportunidade, string nomeCandidato)
        {
            oportunidade.Candidatos.ForEach(c => {

                if (c.Nome == nomeCandidato)
                    c.Aprovado = true;

            });

            return oportunidade;
        }


    }
}
