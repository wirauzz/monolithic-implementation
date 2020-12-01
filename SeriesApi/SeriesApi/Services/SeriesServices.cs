using SeriesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesApi.Services
{

    public class SeriesServices : ISeriesServices
    {
        private List<Serie> seriesDb = new List<Serie>();
        public SeriesServices()
        {
            seriesDb.Add(new Serie()
            {
                id=1,
                name="Rick & Morty",
                gnre = "Comedy",
                rate=5,
                seasons=3
            });

            seriesDb.Add(new Serie()
            {
                id = 2,
                name = "Lucifer",
                gnre = "Drama",
                rate = 5,
                seasons = 2
            });

            seriesDb.Add(new Serie()
            {
                id = 3,
                name = "Casa de papel",
                gnre = "Action",
                rate = 4,
                seasons = 2
            });

        }

        public Serie addSerie(Serie newSerie)
        {
            var serie = seriesDb.OrderByDescending(x => x.id).FirstOrDefault();
            var nextSerieId = serie == null ? 1 : serie.id + 1;
            newSerie.id = nextSerieId;
            seriesDb.Add(newSerie);
            return newSerie;
        }

        public Serie deleteSerie(int id)
        {
            var serie = seriesDb.SingleOrDefault(a => a.id == id);
            if (serie!=null)
            {   
                seriesDb.Remove(serie);
            }
            return serie;
        }

        public Serie getSerie(int id)
        {
            var serie = seriesDb.SingleOrDefault(x => x.id == id);
            return serie;
        }

        public IEnumerable<Serie> getSeries()
        {
            return seriesDb;
        }

        public Serie updateSerie(int id,Serie serieToUp)
        {
            var serie = seriesDb.SingleOrDefault(x => x.id == id);
            if (serie != null)
            {
                serie.name = serieToUp.name;
                serie.gnre = serieToUp.gnre;
                serie.rate = serieToUp.rate;
                serie.seasons = serieToUp.seasons;
            }
            return serie;
        }
    }
}
