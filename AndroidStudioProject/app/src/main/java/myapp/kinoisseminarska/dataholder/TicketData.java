package myapp.kinoisseminarska.dataholder;

import com.squareup.moshi.Json;

public class TicketData {

    @Json(name = "idFilm")
    private int idFilm;
    @Json(name = "idDvorane")
    private int idDvorane;
    @Json(name = "idSedeza")
    private int idSedeza;
    @Json(name = "casZacetka")
    private String casZacetka;
    @Json(name = "casKonca")
    private String casKonca;
    @Json(name = "datum")
    private String datum;
    @Json(name = "cena")
    private float cena;
    @Json(name = "username")
    private String username;

    public int getIdFilm() {
        return idFilm;
    }

    public void setIdFilm(int idFilm) {
        this.idFilm = idFilm;
    }

    public int getIdDvorane() {
        return idDvorane;
    }

    public void setIdDvorane(int idDvorane) {
        this.idDvorane = idDvorane;
    }

    public int getIdSedeza() {
        return idSedeza;
    }

    public void setIdSedeza(int idSedeza) {
        this.idSedeza = idSedeza;
    }

    public String getCasZacetka() {
        return casZacetka;
    }

    public void setCasZacetka(String casZacetka) {
        this.casZacetka = casZacetka;
    }

    public String getCasKonca() {
        return casKonca;
    }

    public void setCasKonca(String casKonca) {
        this.casKonca = casKonca;
    }

    public String getDatum() {
        return datum;
    }

    public void setDatum(String datum) {
        this.datum = datum;
    }

    public float getCena() {
        return cena;
    }

    public void setCena(float cena) {
        this.cena = cena;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
}
