package myapp.kinoisseminarska.webservices;

import java.util.List;

import myapp.kinoisseminarska.dataholder.Show;
import retrofit2.Call;
import retrofit2.http.GET;

public interface GetShows {

    // get all current shows from the server
    @GET("PredstavaAPI/")
    Call<List<Show>> getPredstave();
}
