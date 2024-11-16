using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lendo_me
{
    public class BoardService
    {
        public List<Board> Boards { get; private set; }

        public BoardService()
        {
            Boards = new List<Board>
            {
                new Board("Eu", "Images/Eu.svg"),
                new Board("Rápido", "Images/Rapido.svg"),
                new Board("Você", "Images/Voce.svg"),
            };
        }
    }
}
