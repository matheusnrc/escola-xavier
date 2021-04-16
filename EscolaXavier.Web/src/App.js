import { useEffect, useState } from "react";
import styled from "styled-components";
import { Botao, GlobalStyle } from "./UI/GlobalStyle";
import FormAluno from "./Components/FormAluno";
import FormCurso from "./Components/FormCurso";
import FormMateria from "./Components/FormMateria";
import FormMatricula from "./Components/FormMatricula";
import ListarMatriculados from "./Components/ListarMatriculados";

function App() {
  const [telaExibir, setTelaExibir] = useState("");

  const Pagina = styled.div`
    background-color: black;
    min-height: 100vh;
  `;

  const BotaoSelect = styled.select`
    text-align: center;
    border-radius: 20px;
    padding: 5px 20px;
    margin: 10px 10px;
    font-weight: 600;
    border: 2px solid white;
    cursor: pointer;
    background: black;
    color: white;
    box-shadow: 0 0 0 0;
    outline: 0;
  `;

  const Barra = styled.div`
    background-color: #4a4a4a;
    min-height: 7.5vh;
    display: flex;
    justify-content: center;
  `;

  const Container = styled.div`
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
  `;

  function handleAluno(evento) {
    if (evento.target.value === "Cadastrar Aluno") {
      setTelaExibir(evento.target.value);
    }
  }

  return (
    <Pagina>
      <GlobalStyle />
      <Barra>
        <BotaoSelect onChange={handleAluno}>
          <option>Cadastrar Aluno</option>
          <option>Editar Aluno</option>
          <option>Listar Aluno</option>
        </BotaoSelect>

        <Botao onClick={() => setTelaExibir("Cadastrar Curso")}>
          Cadastrar Curso
        </Botao>
        <Botao onClick={() => setTelaExibir("Cadastrar Materia")}>Cadastrar Matéria</Botao>
        <Botao onClick={() => setTelaExibir("Realizar Matrícula")}>Realizar Matrícula</Botao>
        <Botao onClick={() => setTelaExibir("Exibir Notas")}>Lançar Nota</Botao>
      </Barra>
      <Container>
        {telaExibir == "Cadastrar Aluno" && <FormAluno />}
        {telaExibir === "Cadastrar Curso" && <FormCurso props={"oi"} />}
        {telaExibir === "Cadastrar Materia" && <FormMateria />}
        {telaExibir === "Realizar Matrícula" && <FormMatricula />}
        {telaExibir === "Exibir Notas" && <ListarMatriculados/>}


      </Container>
    </Pagina>
  );
}

export default App;
