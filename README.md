# Pokemon-API

Web API created using ASP.NET Core and Entity Framework in C#.  

Data used comes from [this repo](https://github.com/veekun/pokedex)

## Routes

The following routes are implemented :

HTTP verb | Route | Does | Takes (body) | Returns  
------ | ------ | ------ | ------ | ------
Get | /pokemon/{id} | Returns a pokemon with it's moveset | Nothing | PokemonDTO
Get | /pokemon/{name}/{index}/{count} | Returns a list of pokemons whose name contains the "name" parameter | Nothing | List of SimplePokemonDTO
Get | /pokemon/{id}/Moves/{generation}g/{level} | Returns the list of moves the pokemon at given level, in given generation | Nothing | List of MoveDTO
Get | /move/{id} | Returns a move from it's id | Nothing | MoveDTO
Get | /move/{pokId}/learns/{moveId} | Returns the level a which given pokemon learns for given move | Nothing | Integer (-1 if not found)
Get | /move/{name}/{index}/{count} | Returns a list of moves whose name contains the "name" parameter | Nothing | List of Moves
Post | /damage/gen{generation} | Returns the amount of damage delt following informations given in the body | Gen{Generation}DamageInformationDTO | Integer

If you need more informations about these routes, a Swagger doc will soon be deployed.  
You can use the API here : [http://shrayzz.fr:5242/](http://shrayzz.fr:5242/)

## Limitations

At the moment, this is not planned that the API have any kind of limitations. You should be able to do requests as you will. But if someday there is too many request, I will put some restriction. No route should need authentification, as there is no data to be inserted or modified.
