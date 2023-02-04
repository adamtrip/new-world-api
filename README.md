
# New World API Project

This API uses the data mined files from New World to import them into a db and then serve data via GraphQL.

Requirements:

 - SQL Server | database.json | (the architecture is ready for Postgre, MySQL and Oracle but dunno if it works with those)
 - Redis (optional: this uses some cache to optimize deliver times of the API. if no redis is available it will use RAM)
 - NET Core 7

In order to set it up you'll need to configure `database.json`, `cache.json` and `hangfire.json` with connection strings to the db's.

Then run the Importer endpoint to parse the data from the JSON files into the database. Those files are not up to date.

# Contibute
**Feel free to contibute to the project.** I don't have the time to maintain and develop it within reasonable time, that beeing the main purpose making this publicly available.
If you intend to **create some sort of frontend** using this, feel free to reach out in order to improve security or some other tweaks needed in the API.

# Current Status | 4th Feb 2023
This project is still very early and it does not contain all of the data of the game. It has the basics for now.
Besides that, it needs a lot of improvement in the **Import** part and some other areas of the code.
 - Items
		 - Names and Descriptions
		 - Item Perks and Perk Buckets
		 - Weapon damage values (Base DMG, Crit Change, etc..)
		 - General info (Tier, Rarity, Recipe, GS, etc...)
 - Perks
		 - Names and Descriptions
		 - Afixes
		 - General info
 - Locales
 - Ability Data
 - Affix Data
 - Damage Data
 - Perk Buckets
 - Status Effects Data
 - Weapon Item Definitions

