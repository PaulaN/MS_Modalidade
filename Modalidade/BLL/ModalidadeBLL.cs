using Modalidade.DAO;
using Modalidade.DTO;

namespace Modalidade.BLL
{
    public class ModalidadeBLL
    {
        ModalidadeDAO dao = new ModalidadeDAO();
        int retornoModalidade = 0;

        public ModalidadeDTO retornaModalidadePorNome(String nome)
        {
            ModalidadeDTO modalidadeDTO = new ModalidadeDTO();
            modalidadeDTO = dao.retornaModalidade(nome);
            
            return modalidadeDTO;
        }

        public String insereModalidade(ModalidadeDTO modalidadeDTO)
        {
            retornoModalidade = 0;

           
            if (modalidadeDTO != null)
            {
                retornoModalidade = dao.insereModalidade(modalidadeDTO);
            }
        

            return retornoModalidade == 1 ? "Cadastro realizado com sucesso" : "Não foi possível cadastrar modalidade";
        }



        public String deletaModalidade(String nome)
        {
            retornoModalidade = 0;


            if (nome!= null)
            {
                retornoModalidade = dao.deletaModalidade(nome);



            }

            return retornoModalidade == 1 ? "Dados deletados com sucesso" : "Não foi possível deletar modalidade";
        }

        public String alteraModalidade(ModalidadeDTO modalidadeDTO,String nome)
        {
            retornoModalidade = 0;

            retornoModalidade = dao.alteraModalidade(modalidadeDTO, nome);

            return retornoModalidade == 1 ? "Alteração realizada com sucesso" : "Não foi possível alterar modalidade";
        }

    }
}
