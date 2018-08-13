using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technical_solution.Models
{
    public class Sentenсes
    {
        
        public int Id { get; set; }
        /// <summary>
        /// Name of text file
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Searched sentence
        /// </summary>
        public string Sentenсe { get; set; }
        /// <summary>
        /// Word for search sentense
        /// </summary>
        public string SearchWord { get; set; }
        /// <summary>
        /// number of repetitions of the word
        /// </summary>
        public int Count { get; set; }
    }
}
