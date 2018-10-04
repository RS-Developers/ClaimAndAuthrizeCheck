using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamTreeHouses_API.DataAccess.Entities;
using TeamTreeHouses_API.DataAccess.Repositories;

namespace TeamTreeHouses_API.DataAccess
{
    public class StateService : IStateService
    {
        private Repository<Team> _lTeams = null;
        private Repository<Game> _lGames = null;
        private StatesDbContext _lContext = null;
        private Repository<Player> _lPlayers = null;
        private Repository<GameEvent> _lEvents = null;

        public Repository<Team> Teams
        {
            get
            {
                if (_lTeams == null)
                    _lTeams = new Repository<Team>(_lContext);
                return _lTeams;
            }
        }
        public Repository<Game> Games
        {
            get
            {
                if (_lGames == null)
                    _lGames = new Repository<Game>(_lContext);
                return _lGames;
            }
        }
        public Repository<Player> Players
        {
            get
            {
                if (_lPlayers == null)
                    _lPlayers = new Repository<Player>(_lContext);
                return _lPlayers;
            }
        }
        public Repository<GameEvent> Events
        {
            get
            {
                if (_lEvents == null)
                    _lEvents = new Repository<GameEvent>(_lContext);
                return _lEvents;
            }
        }

        public StateService(StatesDbContext context)
        {
            _lContext = context;
        }
    }
}