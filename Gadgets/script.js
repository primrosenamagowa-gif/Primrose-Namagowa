const gadgetList = document.getElementById("gadget-list");
const searchButton = document.getElementById("searchButton");
const searchInput = document.getElementById("searchInput");
const detailsDiv = document.getElementById("outcomes-details");
const favouritesList = document.getElementById("favourites-list");
const compareList = document.getElementById("compare-list");

let favourites = [];
let compareItems = [];

function renderGadgets(gadgetArray) {
    gadgetList.innerHTML = "";
    gadgetArray.forEach(gadget => {
        if (gadget.type.toLowerCase() === "laptop") {
            const card = document.createElement("div");// Creates an element div which is the card
            card.className = "card";

            const img = document.createElement("img");
            img.src = gadget.image;

            const name = document.createElement("h4");
            name.textContent = gadget.name;
            name.style.cursor = "pointer";

            // When you click the gadget name it is add to favourites
            name.addEventListener("click", () => addToFavourites(gadget));

            const preview = document.createElement("p");
            preview.textContent = `RAM: ${gadget.specs.RAM || "N/A"}`;

            const detailsButton = document.createElement("button");
            detailsButton.textContent = "View Details";
            // when you click view Details it will display the laptop details.
            detailsButton.addEventListener("click", () => showDetails(gadget));

            card.appendChild(img);
            card.appendChild(name);
            card.appendChild(preview);
            card.appendChild(detailsButton);

            gadgetList.appendChild(card);
        }
    });
}

function showDetails(gadget) {
    detailsDiv.innerHTML = `
        <h3>${gadget.name}</h3>
        <img src="${gadget.image}" alt="${gadget.name}" style="width:200px;">
        <p><strong>Price:</strong> ${gadget.price}</p>
        <ul>
            ${Object.entries(gadget.specs).map(([k, v]) => `<li><strong>${k}:</strong> ${v}</li>`).join('')}
        </ul>
            <button id="bookmarkBtn">Bookmark</button>
        <button id="compareBtn">Compare</button>
        <button onclick="window.print()">Print Specs</button>
    `;

    document.getElementById("bookmarkBtn").onclick = () => addToFavourites(gadget);
    document.getElementById("compareBtn").onclick = () => addToCompare(gadget);
}

function addToFavourites(gadget) {
    if (!favourites.some(item => item.name === gadget.name)) {
        favourites.push(gadget);
        updateFavouritesUI();
    }
}

function updateFavouritesUI() {
    favouritesList.innerHTML = "";
    favourites.forEach(item => {
        const fav = document.createElement("p");
        fav.textContent = item.name;
        favouritesList.appendChild(fav);
    });
}

function addToCompare(gadget) {
    if (compareItems.length < 2 && !compareItems.some(item => item.name === gadget.name)) {
        compareItems.push(gadget);
        updateCompareUI();
    }
}

function updateCompareUI() {
    compareList.innerHTML = "";
    if (compareItems.length === 2) {
        const table = document.createElement("table");
        table.border = "1";
        const header = document.createElement("tr");
        header.innerHTML = `<th>Specs</th><th>${compareItems[0].name}</th><th>${compareItems[1].name}</th>`;
        table.appendChild(header);

        const allSpecs = new Set([...Object.keys(compareItems[0].specs), ...Object.keys(compareItems[1].specs)]);

        allSpecs.forEach(spec => {
            const row = document.createElement("tr");
            row.innerHTML = `
                <td>${spec}</td>
                <td>${compareItems[0].specs[spec] || 'N/A'}</td>
                <td>${compareItems[1].specs[spec] || 'N/A'}</td>
            `;
            table.appendChild(row);
        });

        const priceRow = document.createElement("tr");
        priceRow.innerHTML = `<td>Price</td><td>${compareItems[0].price}</td><td>${compareItems[1].price}</td>`;
        table.appendChild(priceRow);

        compareList.appendChild(table);
    } else {
        const placeholder = document.createElement("p");
        placeholder.textContent = "Select Gadget";
        compareList.appendChild(placeholder);
    }
}
const categories =['laptops', 'smartphones'];
function handleSearch(){
    const input =document.querySelector('Search-bar input').value.trim().toLowerCase();
    const categoryResults = document.getElementById('Results');

    if (!input) return;
    if (categories.includes(input)){
        // search by category
        renderGadgets(input);
        categoryResults.textContent =capitalizeFirstLetter(input);

    }else{
        // search by individual gadget name
        SearchGadget(input);
    }

}
document.getElementById('searchButton').addEventListener('click', handleSearch);

document.querySelector('.Search-bar input').addEventListener('keydown', (e)=>
{
    if (e.key ==='Enter')
    {
        handleSearch();
    }
}
);
function SearchGadget(query)
{
  const container = document.getElementById("Laptops");
  container.classList.add("card-group");

  const filtered = gadgets.filter(g =>
    g.name.toLowerCase().includes(query.toLowerCase())
  );
  console.log("Search query:", query);
  console.log("Filtered results:", filtered);

  if (filtered.length === 0)
  {
    document.getElementById("Results").textContent = `No results for "${query}"`;
    container.innerHTML = "<p>No matching gadgets found.</p>";
    return;

  }
 document.getElementById("Results").textContent =`Results for "${query}"`;

 document.getElementById("category-result").textContent = `Results for "${query}"`;

 filtered.forEach(gadget =>
 {
     const card = document.createElement("div");
     card.classList.add("card");

     card.innerHTML = `
     </ul>
     
       <i class="fa-solid fa-magnifying-glass"></i>      
   <img src="${gadget.image}" alt="${gadget.name}">
   <hr>
   <p>${gadget.name}</p>
   <h4>${gadget.price}</h4>
 `;

     group.appendChild(card);
 });

 container.appendChild(group);

}

searchButton.addEventListener("click", () => {
    const query = searchInput.value.toLowerCase();
    const filtered = gadgets.filter(g =>
        g.name.toLowerCase().includes(query) || g.type.toLowerCase().includes(query)
    );
    renderGadgets(filtered);
});

// Initial render
renderGadgets(gadgets);