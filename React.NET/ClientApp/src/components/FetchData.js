import React, { Component } from 'react';

export class Quiz extends Component {
    constructor(props) {
        super(props);
        this.state = { quizzes: [], loading: true };
    }

    componentDidMount() {
        this.validateUser()
    }

    async getData(url = '') {
        const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        return response.json();
    }

    validateUser() {
        if (window.sessionStorage.getItem("userId").trim() === "") {
            return this.props.history.push('/home');
        } else {
            this.getquestions();
        }
    };

    getquestions() {
        this.getData('api/questions/getquestions')
            .then(data => {
                this.setState({
                    quizzes: data
                });
            })
            .catch((error) => {
                alert('Error:', error);
            });
    }

    static renderForecastsTable(forecasts) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map(forecast =>
                        <tr key={forecast.date}>
                            <td>{forecast.date}</td>
                            <td>{forecast.temperatureC}</td>
                            <td>{forecast.temperatureF}</td>
                            <td>{forecast.summary}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    
}
