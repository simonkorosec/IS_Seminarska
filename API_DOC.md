## Vse predstave
- `api/PredstavaAPI`
- GET

##### Retrun
```JSON
[
  {
    "idFilma": 1,
    "naslovFilma": "Iron Man",
    "idDvorane": 1,
    "imeDvorane": "Dvorana 1A",
    "imeKoloseja": "Kolosej Ljubljana",
    "casZacetka": "09:00:00",
    "casKonca": "11:00:00",
    "datum": "2018-12-25"
  }
]
```
---
## Vsi sedeži ki so še na voljo za predstavo
- `api/SedezApi`
- POST

#### Input
```JSON
{
	"idFilm": 1,
	"idDvorane": 1,
	"casZacetka": "09:00:00",
	"casKonca": "11:00:00",
	"datum": "2018-12-25"
}
```
##### Retrun
```JSON
[
  {
    "idSedeza": 2,
    "idDvorane": 1,
    "vrsta": 1,
    "stevilka": 2
  },
  {
    "idSedeza": 3,
    "idDvorane": 1,
    "vrsta": 1,
    "stevilka": 3
  }
]
```
---
## Nakup karte za predstavo
- `api/NakupApi`
- POST

#### Input
```JSON
{
  "idFilm": 1,
  "idDvorane": 1,
  "idSedeza": 3,
  "casZacetka": "09:00:00",
  "casKonca": "11:00:00",
  "datum": "2018-12-25",
  "cena": 6.4
}
```

#### Return
- HTTP.200 if Ok
- HTTP.400 if bad request
