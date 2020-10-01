using System;
using System.Collections.Generic;
using ContatoWeb.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContatoWeb.Controllers
{

    //herança classe controle   
    public class ContatoController : Controller
    {
        // GET: Contato

        /* Os métodos da classe ContatoController são chamados também de Action e têm como retorno 
         * uma ActionResult. Uma ActionResult retorna uma resposta para o cliente, seja ela uma View 
         * (que corresponde a uma página HTML, como no caso dos métodos Read (linha15) e Create (linha 22) ou um redirecionamento para 
         * uma Action como na linha 35.
        As Actions, juntamente com os Controllers formam as URLs da aplicação. Por exemplo, se executarmos o projeto e digitarmos no navegador a URL http://localhost:1234/contato/create 
        teremos o método Create (declarado na linha 20) executado. Se digitarmos a URL http://localhost:1234/contato/index teremos o método Index da linha 10 executado.
        */




        public ActionResult Index()
        {

            using (ContatoModel model = new ContatoModel())
            {
                List<Contato> lista = model.Read();
                return View(lista);
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Contato contato = new Contato();
            contato.Nome = form["Nome"];
            contato.Email = form["Email"];

            using(ContatoModel model = new ContatoModel())
            {
                model.Create(contato);
                return RedirectToAction("Index");
            }
        }


    }
}
