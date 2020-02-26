using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_AList
{
    class Anime
    {
        private int _id;
        private string _name;
        private double _averageScore;
        private DateTime _addDate;
        private string _coverPath;
        private string _description;

        public int Id { get => _id; set => _id = value; }        
        public string Name { get => _name; set => _name = value; }
        public double AverageScore { get => _averageScore; set => _averageScore = value; }
        public DateTime AddDate { get => _addDate; set => _addDate = value; }
        public string CoverPath { get => _coverPath; set => _coverPath = value; }
        public string Description { get => _description; set => _description = value; }

        public Anime(int idParam, string nameParam, double averageScoreParam, DateTime addDateParam, string coverPathParam, string descriptionParam)
        {
            this.Id = idParam;
            this.Name = nameParam;
            this.AverageScore = averageScoreParam;
            this.AddDate = addDateParam;
            this.CoverPath = coverPathParam;
            this.Description = descriptionParam;

        }
    }
}
