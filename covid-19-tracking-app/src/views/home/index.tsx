import React, { ReactElement } from 'react';
import * as bt from 'react-bootstrap';
import { useLocation } from 'react-router-dom';
import { Translation } from '../../components/translation/'
import Navigation from '../../components/navigation/'
import { AppProvider } from '../../contexts/appContext';
import { GetCurrentCountry } from '../../functions';


const Home: React.FC = (): ReactElement => {
    const location = useLocation();
    GetCurrentCountry();

    return (
        <>
            <AppProvider>
                <bt.Container className="justify-content-md-center" style={{ backgroundColor: "red" }}>
                    <bt.Row>
                        <Navigation />
                        <bt.Col md style={{ backgroundColor: "#dffdfd" }}>1 of 1`11111111111111111111111</bt.Col>
                        <bt.Col md style={{ backgroundColor: "#ccc" }}>1 of 2222222222222222222222222222</bt.Col>
                        <bt.Col md style={{ backgroundColor: "#aaa" }}>1 of 3233333333333333333333333333</bt.Col>
                    </bt.Row>
                </bt.Container>

                <h1><Translation tid="home" /></h1>
            </AppProvider>
        </>
    )
};

export default Home;