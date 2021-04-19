import styled, { createGlobalStyle } from "styled-components";
import { Container } from "../../../UI/GlobalStyle";

export const CabecalhoHeader = styled(Container)`
  background-color: #5a5a5a;
  border-radius: 0 0 10px 10px;
  box-shadow: 0 5px 10px #55a6ff38;
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  align-items: center;
  height: 4.75rem;
`;


export const TituloCabecalho = styled.h1`
  font-size: 1.75rem;
  margin-left: 0.5rem;
  color: white;
  text-align: center;
`;