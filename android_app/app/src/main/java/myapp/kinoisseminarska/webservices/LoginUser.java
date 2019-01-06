package myapp.kinoisseminarska.webservices;


import myapp.kinoisseminarska.dataholder.User;
import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface LoginUser {

    @POST("UporabnikApi/login/")
    Call<ResponseBody> loginUser(@Body User user);
}
