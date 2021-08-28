import React from 'react';
import * as bt from 'react-bootstrap';
import { Translation } from '../translation';



const ByGlobal: React.FC = () => {

    return (
        <>
            <bt.Container>
                <bt.Row>
                    <bt.Col md={4}>
                        <h2 className="fs-3">
                            <Translation tid="global_situation_title" />
                        </h2>
                    </bt.Col>
                    <bt.Col> 2</bt.Col>
                </bt.Row>


            </bt.Container>
        </>
    )
}

export default ByGlobal;

