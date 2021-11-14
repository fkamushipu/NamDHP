'use strict';

const e = React.createElement;

class LikeButton extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      news: [],
      top: 0,
      last: 9,
      DataisLoaded: false
  };
}

// ComponentDidMount is used to
// execute the code 
componentDidMount() {
  fetch(
    "https://covid-19-news.p.rapidapi.com/v1/covid?q=covid&lang=en&media=True",
    {
      method: 'GET',
    headers: {
      'x-rapidapi-host': 'covid-19-news.p.rapidapi.com',
      'x-rapidapi-key': 'd82b247df5msh60496cd1428eaadp1a9f6ejsn1cbd579845de'
    }
  })  
        .then((res) => res.json())
        .then((json) => {
            this.setState({
                news: json.articles,
                DataisLoaded: true
            });
            console.log(json);
        }).catch(e=>{
          console.log(e);
        })
  }
  render() {
    const { DataisLoaded, news } = this.state;
    return (
      <div className= "row">
         {
                news.map((n) => ( 
                  <div className="col-md-4 col-sm-2" key = { n._id }>
                    <div className="card primary-shadow rounded-md  pa-2 " style={{width: "35rem"}} >
                      <div className="card-body">
                        <h5 className="card-title"><b>{ n.title }</b></h5>
                        <h6 className="card-subtitle mb-2 text-muted">{ n.published_date } ,
                      <small>Source:</small> <b>{n.clean_url}</b></h6>
                        <p className="card-text">{ n.summary }</p>
                        <a href   =  {n.link} className="card-link">Read More</a>
                      </div>
                    </div>
                  </div>
                ))
            }
      </div>
    );
  }
}

const domContainer = document.querySelector('#covid_news_container');
ReactDOM.render(e(LikeButton), domContainer);