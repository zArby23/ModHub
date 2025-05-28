using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using ModHub.Shared.Entities;
using ModHub.Shared.Enums;

namespace ModHub.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCreatorsAsync();
            await CheckGamesAsync();
            await CheckModsAsync();
            await CheckReportsAsync();
            await CheckCategoriesAsync();
            await CheckGamesCategoriesAsync();
            await CheckForumsAsync();

        }

        private async Task CheckCreatorsAsync()
        {
            if (!_context.Creators.Any())
            {
                _context.Creators.AddRange(new List<Creator>
                {
                    new() { FullName = "Arby23", 
                            Email = "zindax91@gmail.com", 
                            DateRegistration = DateTime.Now },
                    new() { FullName = "SebDuxd",
                            Email = "159sebastian.ramirez.gmail.com", 
                            DateRegistration = DateTime.Now }
                });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckGamesAsync()
        {
            if (!_context.Games.Any())
            {
                _context.Games.AddRange(new List<Game>
                {
                    new() { FullName = "Farming Simulator 22", 
                            Description = "Farming Simulator 22 is a farming simulation game developed by Giants Software."},
                    new() { FullName = "Genshin Impact", 
                            Description = "Genshin Impact is a open world RPG game developed by Hoyoverse."},
                });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckModsAsync()
        {
            if (!_context.Mods.Any())
            {
                _context.Mods.AddRange(new List<Mod>
                {
                    new() { Name = "Arby23's Tractor", 
                            Genre = "Object",
                            Description = "A powerful tractor mod by Arby23.", 
                            CreatorId = 1, 
                            GameId = 1,
                            ModStatus = ModStatus.WIP},
                    new() { Name = "SebDuxd's Harvester", 
                            Genre = "Object",
                            Description = "An efficient harvester mod by SebDuxd.", 
                            CreatorId = 2, 
                            GameId = 1,
                            ModStatus = ModStatus.Abandonado},
                    new() { Name = "Arby23's Sword", 
                            Genre = "Weapon",
                            Description = "A legendary sword mod by Arby23.", 
                            CreatorId = 1, 
                            GameId = 2,
                            ModStatus = ModStatus.Completo},
                    new() { Name = "SebDuxd's Bow", 
                            Genre = "Weapon",
                            Description = "A powerful bow mod by SebDuxd.", 
                            CreatorId = 2, 
                            GameId = 2,
                            ModStatus = ModStatus.Revision}
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task CheckReportsAsync()
        {
            if (!_context.Reports.Any())
            {
                _context.Reports.AddRange(new List<Report>
                {
                    new() { ModId = 1, CreatorId = 2, Title = "Inappropriate content", 
                            Content = "This mod contains inappropriate content." },
                    new() { ModId = 2, CreatorId = 1, Title = "Bug report", 
                            Content = "This mod has a bug that needs fixing." }
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.AddRange(new List<Category>
                {
                    new() { Name = "Indie",
                            Description = "Game developed by an independent studio/developer."},
                    new() { Name = "RPG",
                            Description = "Role-Play Game"},
                    new() { Name = "Single-player",
                            Description = "Game where only one person can played at a time."},
                    new() { Name = "Multiplayer",
                            Description = "Game where multiple people can play it at the same time."},
                    new() { Name = "Open World",
                            Description = "Game which map is pretty big and has nearly no restrictions for exploration."},
                    new() { Name = "Sandbox",
                            Description = "Game where the player can create/destroy anything he wants within the game's gameplay."},
                    new() { Name = "Simulation",
                            Description = "Game where the player simulates to be something."},
                    new() { Name = "Strategy",
                            Description = "Game where the player has to ideate strategies to progress."},
                    new() { Name = "Action",
                            Description = "Game where the player is constantly shot with adrenaline!"},
                    new() { Name = "Adventure",
                            Description = "Game which main focus is on exploration."},
                    new() { Name = "Horror",
                            Description = "Game which main focus is to create tension, suspense and scare the player."},
                    new() { Name = "Puzzle",
                            Description = "Game where the player needs to solve mechanisms to progress."},
                    new() { Name = "Platformer",
                            Description = "Game where the player movement is based on platforms over the levels."},
                    new() { Name = "Sports",
                            Description = "Game where the player immerses itself into a sport game / The game has mechanics that assemble a real life sport."},
                    new() { Name = "Racing",
                            Description = "Game which main focus is on races and getting on first place over a bunch of players/COM players."},
                    new() { Name = "Fighting",
                            Description = "Game where the player has to beat another player/COM player within X rounds in a fight."},
                    new() { Name = "Rhythmic",
                            Description = "Game where the main mechanics relays on music/sounds."}
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task CheckGamesCategoriesAsync()
        {
            if (!_context.GamesCategories.Any())
            {
                var game1 = await _context.Games.FirstOrDefaultAsync(g => g.FullName == "Farming Simulator 22");
                var game2 = await _context.Games.FirstOrDefaultAsync(g => g.FullName == "Genshin Impact");
                var category1 = await _context.Categories.FirstOrDefaultAsync(c => c.Name == "Simulation");
                var category2 = await _context.Categories.FirstOrDefaultAsync(c => c.Name == "RPG");
                if (game1 != null && category1 != null)
                {
                    _context.GamesCategories.Add(new GameCategory { GameId = game1.Id, CategoryId = category1.Id });
                }
                if (game2 != null && category2 != null)
                {
                    _context.GamesCategories.Add(new GameCategory { GameId = game2.Id, CategoryId = category2.Id });
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task CheckForumsAsync()
        {
            if (!_context.Forums.Any())
            {
                _context.Forums.AddRange(new List<Forum>
                {
                    new() { Title = "General Discussion",
                            Content = "Talk about anything related to the game.",
                            GameId = 1},
                    new() { Title = "Modding",
                            Content = "Discuss modding techniques and share your mods.",
                            GameId = 1},
                    new() { Title = "Support",
                            Content = "Get help with issues related to the game or mods.",
                            GameId = 1},
                    new() { Title = "General Discussion",
                            Content = "Talk about anything related to the game.",
                            GameId = 2},
                    new() { Title = "Modding",
                            Content = "Discuss modding techniques and share your mods.",
                            GameId = 2},
                    new() { Title = "Support",
                            Content = "Get help with issues related to the game or mods.",
                            GameId = 2}
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
