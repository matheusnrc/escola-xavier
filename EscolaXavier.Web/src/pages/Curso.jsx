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
} from "../assets/img/components/commonStyle";

const Curso = () => {
  const [nomeCurso, setNomeCurso] = useState("");
  const [listaDeCursos, setListaDeCursos] = useState([]);

  const [idCursoEdicao, setIdEdicao] = useState(0);

  useEffect(async () => {
    await buscarCursos();
  }, []);

  async function cadastrarCurso(evento) {
    evento.preventDefault();
    evento.stopPropagation();


    let retorno = null;
    if (idCursoEdicao == 0)
      retorno = await api.post("Curso/Cadastrar", { nomeCurso });
    else {
      retorno = await api.put("Curso/Editar", { id: idCursoEdicao, nomeCurso });
      setIdEdicao(0);
    }

    alert(retorno.data.dados);
    setNomeCurso("");
    await buscarCursos();
  }

  async function buscarCursos() {
    let cursos = await api.get("Curso/ObterTodos");
    setListaDeCursos(cursos.data.dados);
  }

  async function deletarCurso(id) {
    let deletar = await api.delete(`Curso/Excluir?id=${id}`);
    alert(deletar.data.dados);
    await buscarCursos();
  }

  function preencherEdicao(id, nomeCurso) {
    setNomeCurso(nomeCurso);
    setIdEdicao(id);
  }

  return (
    <main>
      <Container>
        <Box>
          <Titulo>{idCursoEdicao == 0 ? "Cadastro de" : "Editar"} Curso</Titulo>
          <Formulario onSubmit={cadastrarCurso}>
            <Input
              placeholder={"Informe o nome do curso..."}
              onChange={(text) => setNomeCurso(text.target.value)}
              value={nomeCurso}
            />
            <Botao>{idCursoEdicao == 0 ? "Cadastrar" : "Editar"} Curso</Botao>
          </Formulario>
          <TituloLista>Lista de Cursos</TituloLista>

          <CabecalhoLista>
            <DivFlexOne>
              <h3>Cod. Curso</h3>
            </DivFlexOne>
            <DivFlexOne>
              <h3>Nome Curso</h3>
            </DivFlexOne>
            <DivFlexOne>
              <h3>Editar</h3>
            </DivFlexOne>
            <DivFlexOne>
              <h3>Deletar</h3>
            </DivFlexOne>
          </CabecalhoLista>

          {listaDeCursos && listaDeCursos.map((curso, index) => {
            return (
              <ItemLista key={index}>
                <DivFlexOne>{curso.id}</DivFlexOne>
                <DivFlexOne>{curso.nomeCurso}</DivFlexOne>
                <DivFlexOne>
                  <ImgLista
                    src={editar}
                    onClick={() => preencherEdicao(curso.id, curso.nomeCurso)}
                    alt="Editar"
                  />
                </DivFlexOne>
                <DivFlexOne>
                  <ImgLista
                    src={deletar}
                    onClick={() => deletarCurso(curso.id)}
                    alt="Deletar"
                  />
                </DivFlexOne>
              </ItemLista>
            );
          })}
        </Box>
      </Container>
    </main>
  );
};

export default Curso;
