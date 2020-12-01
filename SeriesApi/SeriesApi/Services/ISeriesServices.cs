using SeriesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesApi.Services
{
    public interface ISeriesServices
    {
        IEnumerable<Serie> getSeries();
        Serie getSerie(int id);
        Serie addSerie(Serie serie);
        Serie updateSerie(int id,Serie serie);
        Serie deleteSerie(int id);
    }
}
