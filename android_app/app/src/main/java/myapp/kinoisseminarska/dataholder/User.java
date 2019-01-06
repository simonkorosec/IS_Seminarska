package myapp.kinoisseminarska.dataholder;

import com.squareup.moshi.Json;

public class User {

    @Json(name = "username")
    private String username;
    @Json(name = "password")
    private String password;


    public String getPassword() {
        return password;
    }

    public String getUsername() {
        return username;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public void setUsername(String username) {
        this.username = username;
    }
}
