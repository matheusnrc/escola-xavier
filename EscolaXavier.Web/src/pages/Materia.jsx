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

const Materia = () => {
  const [nomeMateria, setNomeMateria] = useState("");
  const [listaDeMaterias, setListaDeMaterias] = useState([]);
  const [listaDeCursos, setListaDeCursos] = useState([]);

  const [idMateriaEdicao, setIdEdicao] = useState(0);
  const [cursoId, setCursoId] = useState();

  useEffect(async () => {
    await buscarMaterias();
    await buscarCursos();
  }, []);

  async function cadastrarMateria(evento) {
    evento.preventDefault();
    evento.stopPropagation();

    if (validarMateria()) {
      let retorno = null;
      if (idMateriaEdicao == 0)
        retorno = await api.post("Materia/Cadastrar", { nomeMateria, cursoId });
      else {
        retorno = await api.put("Materia/Editar", {
          id: idMateriaEdicao,
          nomeMateria,
          cursoId,
        });
        setIdEdicao(0);
      }

      alert(retorno.data.dados);
      setNomeMateria("");
      setCursoId(0);
      await buscarMaterias();
    }
  }

  function validarMateria() {
    if (nomeMateria == "" || cursoId == undefined) {
      alert("Informe os dados da matéria.");
      return false;
    }

    return true;
  }

  async function buscarMaterias() {
    let materias = await api.get("Materia/ObterTodos");
    setListaDeMaterias(materias.data.dados);
  }

  async function buscarCursos() {
    let cursos = await api.get("Curso/ObterTodos");
    setListaDeCursos(cursos.data.dados);
  }

  async function deletarMateria(id) {
    let deletar = await api.delete(`Materia/Excluir?id=${id}`);
    alert(deletar.data.dados);
    await buscarMaterias();
  }

  function preencherEdicao(id, nomeMateria, cursoId) {
    setNomeMateria(nomeMateria);
    setIdEdicao(id);
    setCursoId(cursoId);
  }

  return (
    <main>
      <Container>
        <Box>
          <Titulo>
            {idMateriaEdicao == 0 ? "Cadastro de" : "Editar"} Matéria
          </Titulo>
          <Formulario onSubmit={cadastrarMateria}>
            <Input
              placeholder={"Informe o nome da matéria..."}
              onChange={(text) => setNomeMateria(text.target.value)}
              value={nomeMateria}
            />

            <Select
              onChange={(evento) => {
                setCursoId(evento.target.value);
              }}
              value={cursoId}
            >
              <option value={0}>Selecione um curso..</option>
              {listaDeCursos &&
                listaDeCursos.map((curso, index) => {
                  return (
                    <option key={index} value={curso.id}>
                      {curso.nomeCurso}
                    </option>
                  );
                })}
            </Select>

            <Botao>
              {idMateriaEdicao == 0 ? "Cadastrar" : "Editar"} Matéria
            </Botao>
          </Formulario>
          {listaDeMaterias && (
            <>
              <TituloLista>Lista de Matéria</TituloLista>
              <CabecalhoLista>
                <DivFlexOne>
                  <h3>Cod. Matéria</h3>
                </DivFlexOne>
                <DivFlexOne>
                  <h3>Nome Matéria</h3>
                </DivFlexOne>
                <DivFlexOne>
                  <h3>Curso</h3>
                </DivFlexOne>
                <DivFlexOne>
                  <h3>Editar</h3>
                </DivFlexOne>
                <DivFlexOne>
                  <h3>Deletar</h3>
                </DivFlexOne>
              </CabecalhoLista>

              {listaDeMaterias &&
                listaDeMaterias.map((materia, index) => {
                  return (
                    <ItemLista key={index}>
                      <DivFlexOne>{materia.id}</DivFlexOne>
                      <DivFlexOne>{materia.nomeMateria}</DivFlexOne>
                      <DivFlexOne>
                        {
                          listaDeCursos.find((x) => x.id == materia.cursoId)
                            .nomeCurso
                        }
                      </DivFlexOne>
                      <DivFlexOne>
                        <ImgLista
                          src={editar}
                          onClick={() =>
                            preencherEdicao(
                              materia.id,
                              materia.nomeMateria,
                              materia.cursoId
                            )
                          }
                          alt="Editar"
                        />
                      </DivFlexOne>
                      <DivFlexOne>
                        <ImgLista
                          src={deletar}
                          onClick={() => deletarMateria(materia.id)}
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

export default Materia;
