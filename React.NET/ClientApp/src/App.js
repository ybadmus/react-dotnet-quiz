import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Score } from './components/Score';

import { FetchData } from './components/FetchData';
//import { Quiz } from './components/FetchData';
//<Route path='/score' component={Score} />


import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/score' component={Score} />

        <Route path='/fetch-data' component={FetchData} />
      </Layout>
    );
  }
}
