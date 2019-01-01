package myapp.kinoisseminarska.webservices;

import java.util.List;

import myapp.kinoisseminarska.dataholder.Seat;
import retrofit2.Call;
import retrofit2.http.Field;
import retrofit2.http.FormUrlEncoded;
import retrofit2.http.POST;

public interface GetAvailableSeats {

    //get list of all available seats for
    @POST("SedezAPI/")
    @FormUrlEncoded
    Call<List<Seat>> getAvailableSeats(@Field("idFilm") int idFilm,
                                       @Field("idDvorane") int idDvorane,
                                       @Field("casZacetka") String casZacetka,
                                       @Field("casKonca") String casKonca,
                                       @Field("datum") String datum);
}
