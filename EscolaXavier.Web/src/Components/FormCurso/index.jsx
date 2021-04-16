import React from "react";
import api from "../../services/api";
import { Botao, Box, Input, Formulario, Titulo } from "../../UI/GlobalStyle";

const FormCurso = (props) => {
  let nomeCurso = "";

  async function cadastrarCurso(evento) {
    //   console.log(props)
    evento.preventDefault();
    evento.stopPropagation();

    let retorno = await api.post("Curso/Cadastrar", { nomeCurso });
    alert(retorno.data.dados);
  }

  return (
    <Box>
      <Titulo>Cadastro de Curso</Titulo>
      <Formulario onSubmit={cadastrarCurso}>
        <Input
          placeholder={"Informe o nome do curso..."}
          onChange={(text) => (nomeCurso = text.target.value)}
        />
        <Botao>Cadastrar Curso</Botao>
      </Formulario>
    </Box>
  );
};

export default FormCurso;
