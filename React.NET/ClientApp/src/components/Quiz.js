import React, { Component } from 'react';
import '../styles/quiz.css';

export class Quiz extends Component {

    constructor(props) {
        super(props);
        this.state = { currentIndex: 0, currentQuestion: "", currentQuestionId: "", quizzes: [], possibleAnswers: [], selectedAnswers: [] };
    }

    componentDidMount() {

        this.validateUser()
        this.getQuestions();
        this.getPossibleAnswers();
    }

    componentDidUpdate(prevProps, prevState) {

        // check if dataSource state is still empty
        if (!prevState.selectedAnswers.length > this.state.selectedAnswers.length) {

            this.getQuestions();
            this.getPossibleAnswers();
        }
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

        if (window.sessionStorage.getItem("userId") === "" || window.sessionStorage.getItem("userId") === null) {
            return this.props.history.push('/');
        } 
    };

    getQuestions() {

        this.getData('api/questions/getquestions')
            .then(data => {
                //this.state.quizzes = data;
                this.setState(function (state, props) {
                    return {
                        quizzes: data
                    };
                });
                this.getCurrentQuestion(this.state.currentIndex);
            })
            .catch((error) => {
                console.log('Error:', error);
            });
    }

    getCurrentQuestion(index) {

        const q = this.state.quizzes[index];
        this.setState({
            currentQuestion: q.questionText, currentQuestionId: q.id
        });
    }

    getPossibleAnswers() {

        this.getData('api/possibleanswers/GetPossibleAnswers')
            .then(data => {
                this.setState(function (state, props) {
                    return {
                        possibleAnswers: data.filter(x => x.questionId === this.state.currentQuestionId)
                    };
                });

            })
            .catch((error) => {
                console.log('Error:', error);
            });
    }

    handleAnswerOptionClick(e, id) {

        let selectedAnswersNew = this.state.selectedAnswers;

        if (!selectedAnswersNew.includes(id)) {

            selectedAnswersNew.push(id);
            this.setState({ selectedAnswers: selectedAnswersNew });
            e.target.classList.add('answer-selected');

        } else {

            this.setState({ selectedAnswers: selectedAnswersNew.filter(x => x !== id) });
            e.target.classList.remove('answer-selected');
        }
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

    handleSaveOfUserEntry() {
        let objToSend = {
            "userId": window.sessionStorage.getItem("userId"),
            "selection": this.state.selectedAnswers,
            "questionId": this.state.currentQuestionId
        }

        this.postData('api/entry/saveentry', objToSend)
            .then(data => {
                alert(data ? "Correct" : "Incorrect");
                this.setState({ currentIndex: this.state.currentIndex + 1 });
            })
            .catch((error) => {
                console.log('Error:', error);
            });

        this.setState({ selectedAnswers: [] });
    }

    render() {
        const { possibleAnswers } = this.state

        return (
            <React.Fragment>
                <div className='quizzes-app'>
                    <div className='question-section'>
                        <div className='question-count'>
                            <span>Question {this.state.currentIndex + 1}</span>/{this.state.quizzes.length}
                        </div>
                        <div className='question-text'>{this.state.currentQuestion}</div>
                    </div>
                    <div className='answer-section'>
                        {possibleAnswers.map((possibleAnswer) => (
                            <button key={possibleAnswer.id} className="question-count" onClick={(e) => this.handleAnswerOptionClick(e, possibleAnswer.id)}>{possibleAnswer.possibleAnswerText}</button>
                        ))}
                    </div>
                </div>

                <button className="question-save" onClick={() => this.handleSaveOfUserEntry()}>Submit</button>
            </React.Fragment>
        );
    }
}
