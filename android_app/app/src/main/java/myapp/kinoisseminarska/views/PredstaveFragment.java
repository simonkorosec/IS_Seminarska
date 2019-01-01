package myapp.kinoisseminarska.views;

import android.content.Context;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ProgressBar;

import java.util.ArrayList;
import java.util.List;

import myapp.kinoisseminarska.R;
import myapp.kinoisseminarska.dataholder.Show;
import myapp.kinoisseminarska.utils.adapters.ShowsRecyclerAdapter;
import myapp.kinoisseminarska.webservices.RestManagment;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;


public class PredstaveFragment extends Fragment {

    private OnFragmentInteractionListener mListener;
    private RecyclerView showRecyclerView;
    private ShowsRecyclerAdapter showsRecyclerAdapter;
    private LinearLayoutManager linearLayoutManager;
    private ProgressBar myProgressBar;

    private List<Show> shows;

    public PredstaveFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootContainer = inflater.inflate(R.layout.fragment_predstave, container, false);

        shows = new ArrayList<>();
        showRecyclerView = rootContainer.findViewById(R.id.predstaveRecyclerView);
        myProgressBar = rootContainer.findViewById(R.id.predstaveProgresBar);
        myProgressBar.setVisibility(View.VISIBLE);
        linearLayoutManager = new LinearLayoutManager(getActivity());

        RestManagment.getPredstave().enqueue(new Callback<List<Show>>() {
            @Override
            public void onResponse(Call<List<Show>> call, Response<List<Show>> response) {
                if(response.code() == 200) {
                    myProgressBar.setVisibility(View.GONE);
                    Log.d("test_is", "Current shows loaded");
                    shows = response.body();

                    showsRecyclerAdapter = new ShowsRecyclerAdapter(shows);
                    showRecyclerView.setLayoutManager(linearLayoutManager);
                    showRecyclerView.setAdapter(showsRecyclerAdapter);
                }
            }
            @Override
            public void onFailure(Call<List<Show>> call, Throwable t) {
                Log.d("test_is", "api '/PredstavaAPI' failed");
            }
        });
        return rootContainer;
    }

    public void onButtonPressed(Uri uri) {
        if (mListener != null) {
            mListener.onFragmentInteraction(uri);
        }
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof OnFragmentInteractionListener) {
            mListener = (OnFragmentInteractionListener) context;
        } else {
            throw new RuntimeException(context.toString()
                    + " must implement OnFragmentInteractionListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener = null;
    }

    public interface OnFragmentInteractionListener {
        void onFragmentInteraction(Uri uri);
    }
}
