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

import java.util.List;

import myapp.kinoisseminarska.R;
import myapp.kinoisseminarska.dataholder.ReturnTicketData;
import myapp.kinoisseminarska.utils.ContentStore;
import myapp.kinoisseminarska.utils.adapters.ReturnedTicketsRecyclerAdapter;
import myapp.kinoisseminarska.webservices.RestManagment;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;


public class PastOrders extends Fragment {

    private OnFragmentInteractionListener mListener;
    private ReturnedTicketsRecyclerAdapter retTicketAdapter;
    private RecyclerView myRecyclerView;
    private LinearLayoutManager myLinearManager;
    private ProgressBar myProgressBar;

    private List<ReturnTicketData> tickets;

    public PastOrders() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View myRoot = inflater.inflate(R.layout.fragment_past_orders, container, false);

        myRecyclerView = myRoot.findViewById(R.id.vstopniceRecyclerView);
        myLinearManager = new LinearLayoutManager(getActivity());
        myProgressBar = myRoot.findViewById(R.id.vstopniceProgresBar);
        myProgressBar.setVisibility(View.VISIBLE);

        ContentStore cntStore = new ContentStore(getActivity().getApplicationContext());


        RestManagment.getAllTicketsByUser(cntStore.getUsername()).enqueue(new Callback<List<ReturnTicketData>>() {
            @Override
            public void onResponse(Call<List<ReturnTicketData>> call, Response<List<ReturnTicketData>> response) {

                if(response.code() == 200) {
                    myProgressBar.setVisibility(View.GONE);
                    Log.d("test_is", "all tickets for user recieved");
                    tickets = response.body();
                    retTicketAdapter = new ReturnedTicketsRecyclerAdapter(tickets);
                    myRecyclerView.setLayoutManager(myLinearManager);
                    myRecyclerView.setAdapter(retTicketAdapter);
                }
            }

            @Override
            public void onFailure(Call<List<ReturnTicketData>> call, Throwable t) {
                Log.d("test_is", "api 'UporabnikApi/username' failed");
            }
        });
        return myRoot;
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
