using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutDemo.Dominio.Entidades;

namespace AutDemo.Dominio.UnitTest
{
    [TestClass]
    public class UsuarioUnitTest
    {
        [TestMethod]
        public void Deve_Criar_Entidade_Usuario_Valida()
        {
            var usuario = new Usuario("Giovani", "giovani@cwi.com.br", "123456");
            Assert.IsTrue(usuario.Validar());
            Assert.IsFalse(usuario.Mensagens.Any());
        }

        [TestMethod]
        public void Nao_Deve_Validar_Entidade_Usuario_Sem_Nome()
        {
            var usuario = new Usuario("", "giovani@cwi.com.br", "123456");
            Assert.IsFalse(usuario.Validar());
            Assert.IsTrue(usuario.Mensagens.Any());
            Assert.IsTrue(usuario.Mensagens[0] == "Nome é inválido.");
        }

        [TestMethod]
        public void Nao_Deve_Validar_Entidade_Usuario_Sem_Email()
        {
            var usuario = new Usuario("Giovani", "", "123456");
            Assert.IsFalse(usuario.Validar());
            Assert.IsTrue(usuario.Mensagens.Any());
            Assert.IsTrue(usuario.Mensagens[0] == "Email é inválido.");
        }

        [TestMethod]
        public void Nao_Deve_Validar_Entidade_Usuario_Sem_Senha()
        {
            var usuario = new Usuario("Giovani", "giovani@cwi.com.br", "");
            Assert.IsFalse(usuario.Validar());
            Assert.IsTrue(usuario.Mensagens.Any());
            Assert.IsTrue(usuario.Mensagens[0] == "Senha é inválido.");
        }

        [TestMethod]
        public void Deve_Validar_Senha_Usuario_Correta()
        {
            var usuario = new Usuario("Giovani", "giovani@cwi.com.br", "123456");
            Assert.IsTrue(usuario.ValidarSenha("123456"));
        }

        [TestMethod]
        public void Deve_Criptografar_Senha_Usuario()
        {
            var usuario = new Usuario("Giovani", "giovani@cwi.com.br", "123456");
            Assert.IsTrue(usuario.Senha != "123456");
        }

        [TestMethod]
        public void Deve_Criar_Usuario_Com_Permissoes_Colaborador()
        {
            var usuario = new Usuario("Giovani", "giovani@cwi.com.br", "123456");
            Assert.IsTrue(usuario.Permissoes.Where(p => p.Nome == "Colaborador").Any());
        }

        [TestMethod]
        public void Deve_Adicionar_Permissao_Colaborador()
        {
            var usuario = new Usuario("Giovani", "giovani@cwi.com.br", "123456");
            usuario.AtribuirPermissoes("Administrador");
            Assert.IsTrue(usuario.Permissoes.Where(p => p.Nome == "Administrador").Any());
        }
    }
}
