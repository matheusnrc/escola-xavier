import React from "react";
import { Link } from "react-router-dom";
import { CabecalhoHeader, TituloCabecalho } from "../../assets/img/components/cabecalhoStyles";
import { DivBotao, DivFlexRow } from "../../assets/img/components/commonStyle";
const Cabecalho = () => {
  return (
    <CabecalhoHeader>
      <div>
        <Link to="/">
          <TituloCabecalho>Escola Xavier</TituloCabecalho>
        </Link>
      </div>

      <DivFlexRow>
        <DivBotao>
          <h2>
            <Link to="/curso" style={{ color: "white" }}>
              Curso
            </Link>
          </h2>
        </DivBotao>
        <DivBotao>
          <h2>
            <Link to="/aluno" style={{ color: "white" }}>
              Aluno
            </Link>
          </h2>
        </DivBotao>
        <DivBotao>
          <h2>
            <Link to="/materia" style={{ color: "white" }}>
              Matéria
            </Link>
          </h2>
        </DivBotao>
        <DivBotao>
          <h2>
            <Link to="/matricula" style={{ color: "white" }}>
              Matrícula
            </Link>
          </h2>
        </DivBotao>
      </DivFlexRow>
    </CabecalhoHeader>
  );
};

export default Cabecalho;
