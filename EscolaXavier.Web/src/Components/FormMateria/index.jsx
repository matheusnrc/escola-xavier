import React, { useEffect, useState } from "react";
import api from "../../services/api";
import {
  Botao,
  Box,
  Input,
  Formulario,
  Titulo,
  Select,
} from "../../UI/GlobalStyle";

const FormMateria = () => {
  let nomeMateria = "";
  let cursoId = null;
  const [cursos, setCursos] = useState([]);

  useEffect(async () => {
    let retorno = await api.get("Curso/ObterTodos");

    setCursos(retorno.data.dados);
  }, []);

  async function cadastrarMateria(evento) {
    evento.preventDefault();
    evento.stopPropagation();

    let retorno = await api.post("Materia/Cadastrar", { nomeMateria, cursoId });
    alert(retorno.data.dados);
  }

  return (
    <Box>
      <Titulo>Cadastro de Matéria</Titulo>
      <Formulario onSubmit={cadastrarMateria}>
        <Input
          placeholder={"Informe o nome da matéria..."}
          onChange={(text) => (nomeMateria = text.target.value)}
        />
        <Select
          onChange={(evento) => {
            cursoId = evento.target.value;
          }}
        >
          <option>Selecione um curso..</option>
          {cursos.map((curso, index) => {
            return (
              <option key={index} value={curso.id}>
                {curso.nomeCurso}
              </option>
            );
          })}
        </Select>
        <Botao>Cadastrar Matéria</Botao>
      </Formulario>
    </Box>
  );
};

export default FormMateria;
