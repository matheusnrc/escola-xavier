import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import Cabecalho from "./components/Cabecalho";
import Aluno from "./pages/Aluno";
import Curso from "./pages/Curso";
import Home from "./pages/Home";
import Materia from "./pages/Materia";
import Matricula from "./pages/Matricula";
import { GlobalStyle } from "./UI/GlobalStyle";

function App() {
  return (
    <Router>
      <GlobalStyle />
      <Cabecalho />
      <Switch>
        <Route exact path="/">
          <Home />
        </Route>
        <Route path="/aluno">
          <Aluno />
        </Route>
        <Route path="/curso">
          <Curso />
        </Route>
        <Route path="/materia">
          <Materia />
        </Route>
        <Route path="/matricula">
          <Matricula />
        </Route>
      </Switch>
    </Router>
  );
}

export default App;
