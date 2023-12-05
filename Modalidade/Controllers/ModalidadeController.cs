using Microsoft.AspNetCore.Mvc;
using Modalidade.BLL;
using Modalidade.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Modalidade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalidadeController : ControllerBase
    {

        ModalidadeBLL bll = new ModalidadeBLL();

        [HttpGet("{nome}")]
        public ModalidadeDTO BuscaPorNome(String nome)
        {
            ModalidadeDTO modalidadeDTO = new ModalidadeDTO();
            modalidadeDTO = bll.retornaModalidadePorNome(nome);


            return modalidadeDTO;
        }


        [HttpPost]
        public String Post(ModalidadeDTO modalidadeDTO)
        {
            String retorno = bll.insereModalidade(modalidadeDTO);

            return retorno;

        }

        [HttpPut("{nome}")]
        public String Put(ModalidadeDTO modalidadeDTO,String nome)
        {
            String retorno = bll.alteraModalidade(modalidadeDTO,nome);

            return retorno;
        }


        [HttpDelete("{nome}")]
        public String Delete(String nome)
        {

            String retorno = bll.deletaModalidade(nome);

            return retorno;
        }

    }
}
