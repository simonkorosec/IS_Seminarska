##### Base URL
`https://kino20181203121922.azurewebsites.net/`

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
  "cena": 6.4,
  "username": "user"
}
```
#### Return
- HTTP.200 if Ok
- HTTP.400 if bad request
---
## Nov Uporabnik
- `api/UporabnikApi/register`
- POST

#### Input
```JSON
{
  "username": "string",
  "password": "string"
}
```
#### Return
- HTTP.200 if Ok, new user created
- HTTP.409 if username taken
---
## Login za uporabnika
- `api/UporabnikApi/login`
- POST

#### Input
```JSON
{
  "username": "string",
  "password": "string"
}
```
#### Return
- HTTP.200 if Ok, password and user are correct
- HTTP.400 if wrong password
---
## Karte od uporabnika
- `api/UporabnikApi/{user-id}`
- GET

#### Return
```JSON
[
  {
    "idSedeza": 1,
    "idFilm": 1,
    "idDvorane": 1,
    "casZacetka": "11:10:00",
    "casKonca": "13:10:00",
    "datum": "2019-01-04",
    "cena": 5.6,
    "username": "user-id"
  }
]
```
