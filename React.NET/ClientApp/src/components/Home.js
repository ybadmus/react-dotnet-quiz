import React, { Component } from 'react';
import '../styles/login.css';

export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = { value: '' };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    
    handleChange(event) {
        this.setState({ value: event.target.value });
    }

    handleSubmit(event) {
        event.preventDefault();
        this.validateUsername(this.state.value) ? this.createUser(this.state.value) : alert("Invalid username (Minimum 4 characters required)");
    }

    validateUsername(username) {
        return username === "" || username.length < 4 ? false : true;
    }

    async postData(url = '', data) {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        return response.json();
    }

    createUser(username) {
        this.postData('api/users/createuser', { username: username })
            .then(data => {
                window.sessionStorage.setItem("userId", data);
                this.props.history.push('/quiz');
            })
            .catch((error) => {
                console.log('Error:', error);
            });
    }

    render() {
        return (
            <div className="login">
                <h1>Login to Quiz App</h1>
                <form onSubmit={this.handleSubmit}>
                    <p><input type="text" value={this.state.value} onChange={this.handleChange} placeholder="Username or Email" /></p>
                    <p className="submit"><input type="submit" name="commit" value="Login" /></p>
                </form>
            </div>
        )
    }
}
