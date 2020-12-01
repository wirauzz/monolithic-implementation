document.getElementById("getSeriesBtn").addEventListener("click",
  async function(){  

    if(document.getElementById("displayTable"))
    {
      var table = document.getElementById("displayTable");
      table.parentNode.removeChild(table)
    }
    try{      
      const request = await fetch('http://localhost:58810/api/series');
      const data = await request.json();

      document.getElementById("seriesContainer").innerHTML +='<table id=displayTable>';
      document.getElementById("displayTable").innerHTML +='<tr id=headers>';
      
      for (i=1; i < Object.keys(data[0]).length ; i++) {
        document.getElementById("headers").innerHTML += `<th> ${Object.keys(data[0])[i].toUpperCase()} </th>`;
      }
      document.getElementById("displayTable").innerHTML +='</tr>';
     

      for (i = 0; i < data.length; i++) {
        var obj = data[i];
        document.getElementById("displayTable").innerHTML += `<tr> <td> ${obj.name} </td> <td> ${obj.gnre} </td> <td> ${obj.rate} </td> <td> ${obj.seasons} </td> <tr>`; 
      }
      document.getElementById("seriesContainer").innerHTML +=`</table>`;
    }catch(error){

    }
});

document.getElementById("getSerieForm").addEventListener("submit", getSerie)
async function getSerie(event) {
  event.preventDefault();
  try {
    const idSerie = event.target.elements;
    const id = idSerie.getIdSerie.value;
    console.log(id);

    const request = await fetch(`http://localhost:58810/api/series/${id}`);
    const data = await request.json();
    console.log(data);
    document.getElementById("serieRow").innerHTML += `${data.name} | ${data.gnre} | ${data.rate} | ${data.seasons}`; 
    
    /*for (i = 0; i < data.length; i++) {
      var obj = data[i];
    }*/
  }
  catch(error){

  }
}

document.getElementById("newSeriesFrm").addEventListener("submit", postSeries)
function postSeries(event){
  console.log(event)
  event.preventDefault();
  const formElements = event.target.elements;
  console.log('formElements', formElements.newSeriesName.value);

  var url = 'http://localhost:58810/api/series';
  var data = {
    name: formElements.newSeriesName.value,
    gnre: formElements.newSeriesGnre.value,
    rate: formElements.newSeriesRating.value,
    seasons: formElements.newSeriesSeasons.value
  };

  console.log(data)
  fetch(url, {
  method: 'POST', // or 'PUT'
  body: JSON.stringify(data), // data can be `string` or {object}!
  headers:{
      'Content-Type': 'application/json'
  }
  }).then((res) => {
      return res.json()})
  .catch(error => console.error('Error:', error))
  .then((response) => {
      console.log('Success:', response)
  });
}

document.getElementById("deleteSerie").addEventListener("submit",deleteSerie)
async function deleteSerie(event){
    event.preventDefault();
    const id = event.target.elements;
    console.log('formelements',id.idSerie.value);
    var url = `http://localhost:58810/api/series/${id.idSerie.value}`;
    await fetch(url, { 
        method: 'DELETE' 
    }); 
}

document.getElementById("putSeriesFrm").addEventListener("submit",putSerie)
function putSerie(event){
    event.preventDefault();
    const formElements = event.target.elements;
   // console.log('formelements',formElements.newMusicName.value);
    var url = `http://localhost:58810/api/series/${formElements.idSerie.value}`;
    var data = {
        id:  formElements.idSerie.value,
        name: formElements.seriesNameToUp.value,
        gnre: formElements.seriesGnreToUp.value,
        rate: formElements.seriesRatingToUp.value,
        seasons: formElements.seriesSeasonsToUp.value
    };
    fetch(url, {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: 'PUT',
        body: JSON.stringify(data)
    }).then((res) => {
      return res.json()})
      .catch(error => console.error('Error:', error))
      .then((response) => {
          console.log('Success:', response)
      });
}


