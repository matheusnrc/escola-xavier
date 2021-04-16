import React from "react";
import api from "../../services/api";
import { Botao, Box, Input, Formulario, Titulo } from "../../UI/GlobalStyle";

const FormAluno = () => {
  let nomeAluno = "";

  async function cadastrarAluno(evento) {
    evento.preventDefault();
    evento.stopPropagation();

    let retorno = await api.post("Aluno/Cadastrar", { nomeAluno });
    alert(retorno.data.dados);
  }

  return (
    <Box>
      <Titulo>Cadastro de Aluno</Titulo>
      <Formulario onSubmit={cadastrarAluno}>
        <Input
          placeholder={"Informe o nome do aluno..."}
          onChange={(text) => (nomeAluno = text.target.value)}
        />
        <Botao>Cadastrar Aluno</Botao>
      </Formulario>
    </Box>
  );
};

export default FormAluno;
