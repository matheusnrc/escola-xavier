import React, { useEffect, useState } from "react";
import api from "../../services/api";
import { Botao, Box, Formulario, Titulo, Select, Input } from "../../UI/GlobalStyle";

const FormMatricula = () => {
  const [materiaId, setMateriaId] = useState();
  const [alunoId, setAlunoId] = useState();
  const [nota, setNota] = useState();


  const [cursoSelecionado, setCursoSelecionado] = useState(
    "Selecione um curso..."
  );

  const [materias, setMaterias] = useState([]);
  const [alunos, setAlunos] = useState([]);

  useEffect(async () => {
    let alunosCadastrados = await api.get("Aluno/ObterTodos");
    let materiasCadastradas = await api.get("Materia/ObterTodos");

    setAlunos(alunosCadastrados.data.dados);
    setMaterias(materiasCadastradas.data.dados);
  }, []);

  async function handleMateria(evento) {
    setMateriaId(evento.target.value);
    let buscarCursoSelecionado = await api.get(
      "Curso/ObterPorId?id=" +
        materias.find((item) => item.id == evento.target.value).cursoId
    );
    setCursoSelecionado(buscarCursoSelecionado.data.dados.nomeCurso);
  }

  async function realizarMatricula(evento) {
    evento.preventDefault();
    evento.stopPropagation();

    let retorno = await api.post("Matricula/Cadastrar", { alunoId, materiaId, nota });
    alert(retorno.data.dados);
  }

  return (
    <Box>
      <Titulo>Realizar Matrícula</Titulo>
      <Formulario onSubmit={realizarMatricula}>
        <Select
          onChange={(evento) => {
            setAlunoId(evento.target.value);
          }}
        >
          <option>Selecione um aluno..</option>
          {alunos.map((aluno, index) => {
            return (
              <option key={index} value={aluno.id}>
                {aluno.nomeAluno}
              </option>
            );
          })}
        </Select>

        <Select onChange={handleMateria}>
          <option>Selecione uma matéria..</option>
          {materias.map((materia, index) => {
            return (
              <option key={index} value={materia.id}>
                {materia.nomeMateria}
              </option>
            );
          })}
        </Select>

        <Select disabled={true}>
          <option>{cursoSelecionado}</option>
        </Select>

        <Input
          placeholder={"Informe a nota do aluno..."}
          onChange={(text) => setNota(parseFloat(text.target.value))}
        />

        <Botao>Realizar Matrícula</Botao>
      </Formulario>
    </Box>
  );
};

export default FormMatricula;
