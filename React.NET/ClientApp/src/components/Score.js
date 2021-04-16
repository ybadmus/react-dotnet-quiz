import React, { Component } from 'react';
import '../styles/login.css';

export class Score extends Component {

    constructor(props) {
        super(props);
        this.state = { score: 0, username: "" };
        this.getScore = this.getScore.bind(this);
    }

    componentDidMount() {
        this.getScore();
    }

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
                console.error('Error:', error);
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
                <h1>Your score: {this.state.username}</h1>
                <strong>{this.state.score}</strong>
            </div>
        );
    }
}

