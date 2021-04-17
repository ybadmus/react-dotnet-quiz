import React, { Component } from 'react';
import { Row, Col, Button } from 'reactstrap';
import '../styles/quiz.css';

export class Quiz extends Component {
    constructor(props) {
        super(props);
        this.state = { possibleAnswers: [], currentIndex: 0, currentQuestion: "", currentQuestionId: "" };
    }

    quizzes = [];
    possibleAnswers = [];

    componentWillMount() {
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
        if (window.sessionStorage.getItem("userId").trim() === "" || window.sessionStorage.getItem("userId").trim() === null) {
            return this.props.history.push('/');
        } else {
            this.getQuestions();
            this.getPossibleAnswers();
        }
    };

    getQuestions() {
        this.getData('api/questions/getquestions')
            .then(data => {
                this.quizzes = data;
                this.getCurrentQuestion(this.state.currentIndex);
            })
            .catch((error) => {
                console.log('Error:', error);
            });
    }

    getCurrentQuestion(index) {
        const q = this.quizzes[index];
        this.setState({
            currentQuestion: q.questionText, currentQuestionId: q.id
        });
    }

    getPossibleAnswers() {
        this.getData('api/possibleanswers/GetPossibleAnswers')
            .then(data => {
                this.possibleAnswers = data;
            })
            .catch((error) => {
                console.log('Error:', error);
            });
    }

    handleAnswerOptionClick(id) {
        alert(id);
    }

    render() {
        return (
            <div className='quizzes-app'>
                <div className='question-section'>
                    <div className='question-count'>
                        <span>Question {this.state.currentIndex + 1}</span>/{this.quizzes.length}
                    </div>
                    <div className='question-text'>{this.state.currentQuestion}</div>
                </div>
                <div className='answer-section'>
                    {this.possibleAnswers.map((possibleAnswer) => (
                        <button className="question-count" onClick={() => this.handleAnswerOptionClick(possibleAnswer.id)}>{possibleAnswer.possibleAnswerText}</button>
                    ))}
                </div>
            </div>
        );
    }


}
