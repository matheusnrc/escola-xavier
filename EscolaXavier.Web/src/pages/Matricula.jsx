import React, { useEffect, useState } from "react";
import api from "../services/api";
import { Container } from "../UI/GlobalStyle";

import editar from "../assets/img/editar.svg";
import deletar from "../assets/img/deletar-usuario.svg";
import {
  Box,
  CabecalhoLista,
  DivFlexOne,
  ImgLista,
  ItemLista,
  Titulo,
  TituloLista,
  Input,
  Formulario,
  Botao,
  Select,
} from "../assets/img/components/commonStyle";

const Matricula = () => {
  const [listaDeMatriculas, setListaDeMatriculas] = useState([]);
  const [listaDeMaterias, setListaDeMaterias] = useState([]);
  const [listaDeAlunos, setListaDeAlunos] = useState([]);

  const [idMatriculaEdicao, setIdEdicao] = useState(0);
  const [materiaId, setMateriaId] = useState();
  const [alunoId, setAlunoId] = useState();
  const [nota, setNota] = useState();

  useEffect(async () => {
    await buscarMatriculas();
    await buscarMaterias();
    await buscarAlunos();
  }, []);

  async function cadastrarMatricula(evento) {
    evento.preventDefault();
    evento.stopPropagation();
    if (validarMatricula()) {
      let retorno = null;
      if (idMatriculaEdicao == 0)
        retorno = await api.post("Matricula/Cadastrar", {
          alunoId,
          materiaId,
          nota: parseFloat(nota),
        });
      else {
        retorno = await api.put("Matricula/Editar", {
          id: idMatriculaEdicao,
          alunoId,
          materiaId,
          nota,
        });
        setIdEdicao(0);
      }

      alert(retorno.data.dados);
      setAlunoId(0);
      setMateriaId(0);
      setNota("");
      await buscarMatriculas();
    }
  }

  async function buscarMaterias() {
    let materias = await api.get("Materia/ObterTodos");
    setListaDeMaterias(materias.data.dados);
  }

  async function buscarAlunos() {
    let alunos = await api.get("Aluno/ObterTodos");
    setListaDeAlunos(alunos.data.dados);
  }

  async function buscarMatriculas() {
    let matriculas = await api.get("Matricula/ObterTodosDetalhado");
    setListaDeMatriculas(matriculas.data.dados);
  }

  async function deletarMateria(id) {
    let deletar = await api.delete(`Matricula/Excluir?id=${id}`);
    alert(deletar.data.dados);
    await buscarMatriculas();
  }

  function preencherEdicao(id, alunoId, materiaId, nota) {
    setIdEdicao(id);
    setAlunoId(alunoId);
    setMateriaId(materiaId);
    setNota(nota);
  }

  function validarMatricula() {
    if (alunoId == undefined || materiaId == undefined) {
      alert("Informe os dados da matrícula.");
      return false;
    }

    if (nota != undefined && (parseFloat(nota) < 0 || parseFloat(nota) > 10)) {
      alert(
        "Informe a nota corretamente, apenas valores de 0 - 10 são aceitos."
      );
      return false;
    }
    return true;
  }

  return (
    <main>
      <Container>
        <Box>
          <Titulo>
            {idMatriculaEdicao == 0 ? "Cadastro de" : "Editar"} Matrícula
          </Titulo>
          <Formulario onSubmit={cadastrarMatricula}>
            <Select
              onChange={(evento) => {
                setAlunoId(evento.target.value);
              }}
              value={alunoId}
            >
              <option value={0}>Selecione um aluno..</option>
              {listaDeAlunos &&
                listaDeAlunos.map((aluno, index) => {
                  return (
                    <option key={index} value={aluno.id}>
                      {aluno.nomeAluno}
                    </option>
                  );
                })}
            </Select>

            <Select
              onChange={(evento) => {
                setMateriaId(evento.target.value);
              }}
              value={materiaId}
            >
              <option value={0}>Selecione uma matéria...</option>
              {listaDeMaterias &&
                listaDeMaterias.map((materia, index) => {
                  return (
                    <option key={index} value={materia.id}>
                      {materia.nomeMateria}
                    </option>
                  );
                })}
            </Select>

            <Input
              placeholder={"Informe a nota do aluno..."}
              onChange={(text) => setNota(text.target.value)}
              value={nota}
            />

            <Botao>
              {idMatriculaEdicao == 0 ? "Cadastrar" : "Editar"} Matrícula
            </Botao>
          </Formulario>
          {listaDeMatriculas.length > 0 && (
            <>
              <TituloLista>Lista de Matrícula</TituloLista>
              <CabecalhoLista>
                <DivFlexOne>
                  <h3>Cod. Matrícula</h3>
                </DivFlexOne>
                <DivFlexOne>
                  <h3>Aluno</h3>
                </DivFlexOne>
                <DivFlexOne>
                  <h3>Matéria</h3>
                </DivFlexOne>
                <DivFlexOne>
                  <h3>Nota</h3>
                </DivFlexOne>
                <DivFlexOne>
                  <h3>Situação</h3>
                </DivFlexOne>
                <DivFlexOne>
                  <h3>Editar</h3>
                </DivFlexOne>
                <DivFlexOne>
                  <h3>Deletar</h3>
                </DivFlexOne>
              </CabecalhoLista>

              {listaDeMatriculas.map((matricula, index) => {
                return (
                  <ItemLista key={index}>
                    <DivFlexOne>{matricula.id}</DivFlexOne>
                    <DivFlexOne>{matricula.nomeAluno}</DivFlexOne>
                    <DivFlexOne>{matricula.nomeMateria}</DivFlexOne>
                    <DivFlexOne>
                      {matricula.nota ?? "Não informado."}
                    </DivFlexOne>
                    <DivFlexOne>
                      {matricula.status ? matricula.status : "Cursando"}
                    </DivFlexOne>
                    <DivFlexOne>
                      <ImgLista
                        src={editar}
                        onClick={() =>
                          preencherEdicao(
                            matricula.id,
                            matricula.alunoId,
                            matricula.materiaId,
                            matricula.nota
                          )
                        }
                        alt="Editar"
                      />
                    </DivFlexOne>
                    <DivFlexOne>
                      <ImgLista
                        src={deletar}
                        onClick={() => deletarMateria(matricula.id)}
                        alt="Deletar"
                      />
                    </DivFlexOne>
                  </ItemLista>
                );
              })}
            </>
          )}
        </Box>
      </Container>
    </main>
  );
};

export default Matricula;
