# 1. Vehicles i manteniments

⦁	Vehicles: Id (uniqueidentifier - no significatiu), matrícula, model, propietari (uniqueidentifier)

⦁	Manteniments: Id (uniqueidentifier - no significatiu), IdVehicle (uniqueidentifier), data.

⦁	Treballador: Id (uniqueidentifier - no signaficatiu), NSS, Nom, Categoria.

⦁	Hores - Treballador: Id (uniqueidentifier - no signaficatiu), IdTreballador, IdManteniment, PreuHora, QuantitatHores.

## Funcionalitats

⦁	Donar d'alta un vehicle a la base de dades.

context: vehicle
on es fa: vehicle

POST /vehicles

{
“matricula”:”____”
“model”:”____”
“propietari”:”____”
}

⦁	Crear un manteniment pel vehicle X. L'usuari obrirà la fitxa del vehicle i polsarà sobre el botó "Afegir" associat a la funcionalitat de manteniments.

context: manteniment
on es fa: manteniment
POST /manteniment/{id}/vehicle/{idVehicle}
{
“data”:”____”
}
⦁	Modificar les hores d'un determinat manteniment. L'usuari seleccionarà el manteniment de la llista de manteniments associats a un vehicle i indicarà el total d'hores que s'hi vol imputar.

PUT /hores/{id}
{
“QuantitalHores”:”___”
}



⦁	Llistar tots els manteniments d'un vehicle.

contexte: manteniments
on es fa: manteniments

GET /manteniments


⦁	Crear un nou treballador.

contexte: treballador
on es fa: treballador

POST /treballador
{
“NSS”:”____”
“Nom”:”____”
“Categoria”:”____”
}
⦁	Obtenir l'import d'un manteniment.
contexte: manteniment
on es fa: manteniment
GET /manteniment/{id}/import


⦁	Obtenir l'import de tots els manteniments que s'han fet a un vehicle.
contexte: manteniments
on es fa: vehicle
GET /vehicle/{idVehicle}/manteniments/import

⦁	Obtenir totes les hores treballades per un treballador.
context: treballador
on es fa: hores
GET /treballador/quantiathores/

⦁	Llistar tots els manteniments en què ha participat un treballador.
context: treballador
on es fa: manteniment
GET /treballador/{id}/manteniments

⦁	Obtenir el cost total d’un treballador (hores × preu).

context: treballador
on es fa: treballador
GET /treballador/{id}/cost


⦁	Consultar tots els treballadors assignats a un manteniment.
context: manteniment
on es fa: treballador
get /treballadors/manteniment/{id}

⦁	Canviar el propietari d’un vehicle.
context: vehicle
on es fa: vehicle

PATCH /vehicle

{
“Propietari”: “___”
}

⦁	Actualitzar dades d’un treballador.

context: treballador
on es fa: treballador

PUT /treballador/{id}

{
“NSS”:”____”
“Nom”:”____”
“Categoria”:”____”
}










⦁	Incrementar el preu hora associat a un treballador.
context: treballador
on es fa: hora

PATCH /hores/{idTreballador}

{
“preuhora”:”____”
}








## Tasca

⦁	Per a cada funcionalitat cal:

⦁	Especificar l'entitat context.

⦁	Especificar l'entitat sobre la qual passa l'acció.

⦁	Especificar l'end point a aplicar amb tota la informació associada al mateix
