using System;
using System.Collections.Generic;
using System.Linq;

namespace Opgave_1_og_2___Obl_Opgave
{
    public class TrophiesRepository
    {
        private List<Trophy> _trophies;
        private int _nextId;

        public TrophiesRepository()
        {
            _trophies = new List<Trophy>
            {
                new Trophy { Id = 1, Competition = "Regional Mester i Letsværvægt", Year = 2020 },
                new Trophy { Id = 2, Competition = "Danmarksmester", Year = 2019 },
                new Trophy { Id = 3, Competition = "HSK Box Cup", Year = 2021 },
                new Trophy { Id = 4, Competition = "Sjællandsmester", Year = 2018 },
                new Trophy { Id = 5, Competition = "Serie 3 Fodbold", Year = 2022 }
            };
            _nextId = 6;
        }

        public List<Trophy> Get(int? year = null, string sortBy = null)
        {
            var result = _trophies.ToList();

            if (year.HasValue)
            {
                result = result.Where(t => t.Year == year.Value).ToList();
            }

            if (sortBy != null)
            {
                result = sortBy.ToLower() switch
                {
                    "competition" => result.OrderBy(t => t.Competition).ToList(),
                    "year" => result.OrderBy(t => t.Year).ToList(),
                    _ => result
                };
            }

            return result;
        }

        public Trophy GetById(int id)
        {
            return _trophies.FirstOrDefault(t => t.Id == id);
        }

        public Trophy Add(Trophy trophy)
        {
            trophy.Id = _nextId++;
            _trophies.Add(trophy);
            return trophy;
        }

        public Trophy Remove(int id)
        {
            var trophy = GetById(id);
            if (trophy != null)
            {
                _trophies.Remove(trophy);
            }
            return trophy;
        }

        public Trophy Update(int id, Trophy values)
        {
            var trophy = GetById(id);
            if (trophy != null)
            {
                trophy.Competition = values.Competition;
                trophy.Year = values.Year;
            }
            return trophy;
        }
    }
}