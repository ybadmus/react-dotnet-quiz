import React, { Component } from 'react';
import '../styles/score.css';

export class Score extends Component {

    constructor(props) {
        super(props);
        this.state = { score: 0, username: "" };
        this.getScore = this.getScore.bind(this);
    }

    componentDidMount() {
        this.validateUser();
    }

    validateUser() {
        if (window.sessionStorage.getItem("userId") === "" || window.sessionStorage.getItem("userId") === null) {
            return this.props.history.push('/');
        } else {
            this.getScore();
        }
    };

    componentWillUnmount() {
        window.sessionStorage.setItem("userId", "");
    }

    getScore() {
        this.getData('api/users/getscores?userid=' + window.sessionStorage.getItem("userId"))
            .then(data => {
                this.setState({
                    score: this.state.score + data.score,
                    username: data.username
                });
            })
            .catch((error) => {
                console.log('Error:', error);
            });
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

    render() {
        return (
            <div className="score">
                <h1>Name: {this.state.username}</h1>
                <strong>Score: {this.state.score} %</strong>
            </div>
        );
    }
}

