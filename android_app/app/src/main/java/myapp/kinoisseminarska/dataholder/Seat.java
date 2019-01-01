package myapp.kinoisseminarska.dataholder;

import com.squareup.moshi.Json;

public class Seat {

    @Json(name = "idSedeza")
    private int idSedeza;
    @Json(name = "idDvorane")
    private int idDvorane;
    @Json(name = "vrsta")
    private int vrsta;
    @Json(name = "stevilka")
    private int stevilka;

    public int getIdSedeza() {
        return idSedeza;
    }

    public void setIdSedeza(int idSedeza) {
        this.idSedeza = idSedeza;
    }

    public int getIdDvorane() {
        return idDvorane;
    }

    public void setIdDvorane(int idDvorane) {
        this.idDvorane = idDvorane;
    }

    public int getVrsta() {
        return vrsta;
    }

    public void setVrsta(int vrsta) {
        this.vrsta = vrsta;
    }

    public int getStevilka() {
        return stevilka;
    }

    public void setStevilka(int stevilka) {
        this.stevilka = stevilka;
    }

}