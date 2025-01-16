--
-- PostgreSQL database dump
--

-- Dumped from database version 15.0
-- Dumped by pg_dump version 15.0

-- Started on 2022-12-13 18:38:21 WET

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 226 (class 1259 OID 16572)
-- Name: Alert; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Alert" (
    "HardwareidHardware" integer NOT NULL,
    "maxValue" integer NOT NULL,
    "minValue" integer NOT NULL
);


ALTER TABLE public."Alert" OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 16583)
-- Name: Data; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Data" (
    "idData" integer NOT NULL,
    "HardwareidHardware" integer NOT NULL,
    "idDataType" integer NOT NULL,
    value character varying NOT NULL,
    "registrationDate" date NOT NULL
);


ALTER TABLE public."Data" OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16522)
-- Name: DataType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."DataType" (
    "idDataType" integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public."DataType" OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 16521)
-- Name: DataType_idDataType_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."DataType" ALTER COLUMN "idDataType" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."DataType_idDataType_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 227 (class 1259 OID 16582)
-- Name: Data_idData_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Data" ALTER COLUMN "idData" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Data_idData_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 219 (class 1259 OID 16514)
-- Name: FuncionalityType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."FuncionalityType" (
    "idFuncionality" integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public."FuncionalityType" OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 16513)
-- Name: FuncionalityType_idFuncionality_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."FuncionalityType" ALTER COLUMN "idFuncionality" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."FuncionalityType_idFuncionality_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 223 (class 1259 OID 16530)
-- Name: Hardware; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Hardware" (
    "idHardware" integer NOT NULL,
    "HardwareTypeidHardwareType" integer NOT NULL,
    "FuncionalityTypeidFunctionality" integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public."Hardware" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16506)
-- Name: HardwareType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."HardwareType" (
    "idHardwareType" integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public."HardwareType" OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 16505)
-- Name: HardwareType_idHardwareType_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."HardwareType" ALTER COLUMN "idHardwareType" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."HardwareType_idHardwareType_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 222 (class 1259 OID 16529)
-- Name: Hardware_idHardware_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Hardware" ALTER COLUMN "idHardware" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Hardware_idHardware_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 225 (class 1259 OID 16562)
-- Name: InstallationHistoric; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."InstallationHistoric" (
    "HardwareidHardware" integer NOT NULL,
    "idRoom" integer NOT NULL,
    "registrationDate" date NOT NULL,
    "idUser" integer NOT NULL
);


ALTER TABLE public."InstallationHistoric" OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16498)
-- Name: State; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."State" (
    "idState" integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public."State" OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 16547)
-- Name: StateHistoric; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."StateHistoric" (
    "registrationDate" date NOT NULL,
    "HardwareidHardware" integer NOT NULL,
    "StateidState" integer NOT NULL
);


ALTER TABLE public."StateHistoric" OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 16497)
-- Name: State_idState_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."State" ALTER COLUMN "idState" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."State_idState_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 3676 (class 0 OID 16572)
-- Dependencies: 226
-- Data for Name: Alert; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Alert" ("HardwareidHardware", "maxValue", "minValue") FROM stdin;
\.


--
-- TOC entry 3678 (class 0 OID 16583)
-- Dependencies: 228
-- Data for Name: Data; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Data" ("idData", "HardwareidHardware", "idDataType", value, "registrationDate") FROM stdin;
\.


--
-- TOC entry 3671 (class 0 OID 16522)
-- Dependencies: 221
-- Data for Name: DataType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."DataType" ("idDataType", name) FROM stdin;
\.


--
-- TOC entry 3669 (class 0 OID 16514)
-- Dependencies: 219
-- Data for Name: FuncionalityType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."FuncionalityType" ("idFuncionality", name) FROM stdin;
\.


--
-- TOC entry 3673 (class 0 OID 16530)
-- Dependencies: 223
-- Data for Name: Hardware; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Hardware" ("idHardware", "HardwareTypeidHardwareType", "FuncionalityTypeidFunctionality", name) FROM stdin;
\.


--
-- TOC entry 3667 (class 0 OID 16506)
-- Dependencies: 217
-- Data for Name: HardwareType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."HardwareType" ("idHardwareType", name) FROM stdin;
\.


--
-- TOC entry 3675 (class 0 OID 16562)
-- Dependencies: 225
-- Data for Name: InstallationHistoric; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."InstallationHistoric" ("HardwareidHardware", "idRoom", "registrationDate", "idUser") FROM stdin;
\.


--
-- TOC entry 3665 (class 0 OID 16498)
-- Dependencies: 215
-- Data for Name: State; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."State" ("idState", name) FROM stdin;
1	Ativo
2	Desativo
\.


--
-- TOC entry 3674 (class 0 OID 16547)
-- Dependencies: 224
-- Data for Name: StateHistoric; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."StateHistoric" ("registrationDate", "HardwareidHardware", "StateidState") FROM stdin;
\.


--
-- TOC entry 3684 (class 0 OID 0)
-- Dependencies: 220
-- Name: DataType_idDataType_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."DataType_idDataType_seq"', 1, false);


--
-- TOC entry 3685 (class 0 OID 0)
-- Dependencies: 227
-- Name: Data_idData_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Data_idData_seq"', 1, false);


--
-- TOC entry 3686 (class 0 OID 0)
-- Dependencies: 218
-- Name: FuncionalityType_idFuncionality_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."FuncionalityType_idFuncionality_seq"', 1, false);


--
-- TOC entry 3687 (class 0 OID 0)
-- Dependencies: 216
-- Name: HardwareType_idHardwareType_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."HardwareType_idHardwareType_seq"', 1, false);


--
-- TOC entry 3688 (class 0 OID 0)
-- Dependencies: 222
-- Name: Hardware_idHardware_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Hardware_idHardware_seq"', 1, false);


--
-- TOC entry 3689 (class 0 OID 0)
-- Dependencies: 214
-- Name: State_idState_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."State_idState_seq"', 2, true);


--
-- TOC entry 3513 (class 2606 OID 16576)
-- Name: Alert Alert_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Alert"
    ADD CONSTRAINT "Alert_pkey" PRIMARY KEY ("HardwareidHardware", "maxValue", "minValue");


--
-- TOC entry 3505 (class 2606 OID 16528)
-- Name: DataType DataType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."DataType"
    ADD CONSTRAINT "DataType_pkey" PRIMARY KEY ("idDataType");


--
-- TOC entry 3503 (class 2606 OID 16520)
-- Name: FuncionalityType FuncionalityType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."FuncionalityType"
    ADD CONSTRAINT "FuncionalityType_pkey" PRIMARY KEY ("idFuncionality");


--
-- TOC entry 3501 (class 2606 OID 16512)
-- Name: HardwareType HardwareType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HardwareType"
    ADD CONSTRAINT "HardwareType_pkey" PRIMARY KEY ("idHardwareType");


--
-- TOC entry 3507 (class 2606 OID 16536)
-- Name: Hardware Hardware_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Hardware"
    ADD CONSTRAINT "Hardware_pkey" PRIMARY KEY ("idHardware");


--
-- TOC entry 3511 (class 2606 OID 16566)
-- Name: InstallationHistoric InstallationHistoric_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."InstallationHistoric"
    ADD CONSTRAINT "InstallationHistoric_pkey" PRIMARY KEY ("HardwareidHardware", "idRoom", "registrationDate", "idUser");


--
-- TOC entry 3509 (class 2606 OID 16551)
-- Name: StateHistoric StateHistoric_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."StateHistoric"
    ADD CONSTRAINT "StateHistoric_pkey" PRIMARY KEY ("registrationDate", "HardwareidHardware");


--
-- TOC entry 3499 (class 2606 OID 16504)
-- Name: State State_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."State"
    ADD CONSTRAINT "State_pkey" PRIMARY KEY ("idState");


--
-- TOC entry 3514 (class 2606 OID 16537)
-- Name: Hardware functionalityType; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Hardware"
    ADD CONSTRAINT "functionalityType" FOREIGN KEY ("FuncionalityTypeidFunctionality") REFERENCES public."FuncionalityType"("idFuncionality") MATCH FULL ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3515 (class 2606 OID 16542)
-- Name: Hardware hardwareType; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Hardware"
    ADD CONSTRAINT "hardwareType" FOREIGN KEY ("HardwareTypeidHardwareType") REFERENCES public."HardwareType"("idHardwareType") MATCH FULL ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3520 (class 2606 OID 16593)
-- Name: Data idDataType; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Data"
    ADD CONSTRAINT "idDataType" FOREIGN KEY ("idDataType") REFERENCES public."DataType"("idDataType") MATCH FULL ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3516 (class 2606 OID 16552)
-- Name: StateHistoric idHardware; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."StateHistoric"
    ADD CONSTRAINT "idHardware" FOREIGN KEY ("HardwareidHardware") REFERENCES public."Hardware"("idHardware") MATCH FULL ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3518 (class 2606 OID 16567)
-- Name: InstallationHistoric idHardware; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."InstallationHistoric"
    ADD CONSTRAINT "idHardware" FOREIGN KEY ("HardwareidHardware") REFERENCES public."Hardware"("idHardware") MATCH FULL ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3519 (class 2606 OID 16577)
-- Name: Alert idHardware; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Alert"
    ADD CONSTRAINT "idHardware" FOREIGN KEY ("HardwareidHardware") REFERENCES public."Hardware"("idHardware") MATCH FULL ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3521 (class 2606 OID 16588)
-- Name: Data idHardware; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Data"
    ADD CONSTRAINT "idHardware" FOREIGN KEY ("HardwareidHardware") REFERENCES public."Hardware"("idHardware") MATCH FULL ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3517 (class 2606 OID 16557)
-- Name: StateHistoric idState; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."StateHistoric"
    ADD CONSTRAINT "idState" FOREIGN KEY ("StateidState") REFERENCES public."State"("idState") MATCH FULL ON UPDATE RESTRICT ON DELETE RESTRICT;


-- Completed on 2022-12-13 18:38:21 WET

--
-- PostgreSQL database dump complete
--

