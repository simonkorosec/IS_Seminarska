package myapp.kinoisseminarska.dataholder;

import com.squareup.moshi.Json;

import java.io.Serializable;

public class Show implements Serializable {

    @Json(name = "idFilm")
    private int idFilma;
    @Json(name = "naslovFilma")
    private String naslovFilma;
    @Json(name = "idDvorane")
    private int idDvorane;
    @Json(name = "imeDvorane")
    private String imeDvorane;
    @Json(name = "imeKoloseja")
    private String imeKoloseja;
    @Json(name = "casZacetka")
    private String casZacetka;
    @Json(name = "casKonca")
    private String casKonca;
    @Json(name = "datum")
    private String datum;

    public int getIdFilma() {
        return idFilma;
    }

    public void setIdFilma(int idFilma) {
        this.idFilma = idFilma;
    }

    public String getNaslovFilma() {
        return naslovFilma;
    }

    public void setNaslovFilma(String naslovFilma) {
        this.naslovFilma = naslovFilma;
    }

    public int getIdDvorane() {
        return idDvorane;
    }

    public void setIdDvorane(int idDvorane) {
        this.idDvorane = idDvorane;
    }

    public String getImeDvorane() {
        return imeDvorane;
    }

    public void setImeDvorane(String imeDvorane) {
        this.imeDvorane = imeDvorane;
    }

    public String getImeKoloseja() {
        return imeKoloseja;
    }

    public void setImeKoloseja(String imeKoloseja) {
        this.imeKoloseja = imeKoloseja;
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

    @Override
    public String toString() {
        return "id filma : " + getIdFilma() +
                "id dvorane : " + getImeDvorane() +
                "ime koloseja: " + getImeKoloseja() +
                "naslov filma:  " + getNaslovFilma() +
                "datum: " + getDatum() +
                "id dovrane: " + getImeDvorane() +
                "cas konca: " + getCasKonca() +
                "cas zacetka: " + getCasZacetka();
    }
}