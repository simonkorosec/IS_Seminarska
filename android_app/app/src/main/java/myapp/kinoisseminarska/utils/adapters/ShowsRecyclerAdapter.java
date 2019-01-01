package myapp.kinoisseminarska.utils.adapters;

import android.content.Context;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;

import java.util.List;

import myapp.kinoisseminarska.R;
import myapp.kinoisseminarska.dataholder.Show;


public class ShowsRecyclerAdapter
        extends RecyclerView.Adapter<ShowsRecyclerAdapter.DiscoveryRecyclerHolder> {

    private List<Show> shows;
    @NonNull
    private Show currentShow;

    // Define the View Holder
    static class DiscoveryRecyclerHolder extends RecyclerView.ViewHolder {
        LinearLayout cardContainer;
        TextView imeFilmaText;
        TextView imeDvoraneText;
        TextView casZacetkaText;
        TextView casKoncaText;
        TextView datumText;

        DiscoveryRecyclerHolder(final View itemView) {
            super(itemView);
            // Initialize the parameters based on the Card layout names
            cardContainer = itemView.findViewById(R.id.cardShowContainer);
            imeFilmaText = itemView.findViewById(R.id.imeFilmaText);
            imeDvoraneText = itemView.findViewById(R.id.dvoranaText);
            casZacetkaText = itemView.findViewById(R.id.casZacetkaText);
            casKoncaText = itemView.findViewById(R.id.casKoncaText);
            datumText = itemView.findViewById(R.id.datumText);
        }
    }

    // Adapter constructor
    public ShowsRecyclerAdapter(List<Show> shows) {
        this.shows = shows;
    }
    /*
    onCreateViewHolder, onBindViewHolder and getItemCount() HAVE to be defined in order to get rid
    of the errors!
    */

    @NonNull
    @Override
    public DiscoveryRecyclerHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        // Find and inflate the appropriate card layout.
        // In this case layout/card_discovery.xml
        View cardShowView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.card_show, parent, false);

        return new DiscoveryRecyclerHolder(cardShowView);
    }

    @Override
    public void onBindViewHolder(@NonNull final DiscoveryRecyclerHolder holder, int position) {
        // Get the restaurant home info for the appropriate restaurant
        Show showInfo = this.shows.get(position);
        Context myContext = holder.imeDvoraneText.getContext();

        holder.imeFilmaText.setText(showInfo.getNaslovFilma());
        holder.imeDvoraneText.setText(showInfo.getImeDvorane());
        holder.casZacetkaText.setText(showInfo.getCasZacetka());
        holder.casKoncaText.setText(showInfo.getCasKonca());
        holder.datumText.setText(showInfo.getDatum());


        holder.cardContainer.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                currentShow = shows.get(holder.getAdapterPosition());

            }
        });
    }

    @Override
    public int getItemCount() {
        return shows.size();
    }

}
