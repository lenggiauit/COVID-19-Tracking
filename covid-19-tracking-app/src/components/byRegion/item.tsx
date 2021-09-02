import React from 'react';
import { Covid19DataByRegion } from '../../types/covid19DataByRegion';
import * as bt from 'react-bootstrap';
import Placeholder from 'react-bootstrap/Placeholder';
import { GetRandomBgColor } from '../../utils/functions';
import "./regionItem.css";
import { Translation } from '../translation';
import { Doughnut } from 'react-chartjs-2';
import { RegionColors } from '../../types/colors';

type Props = {
    data?: Covid19DataByRegion;
    max: number;
    selectedItem(arg?: Covid19DataByRegion): void;
}

const RegionItem: React.FC<Props> = ({ data, max, selectedItem }) => {

    const handleClick = () => {
        selectedItem(data)!;
    }
    if (data != null) {
        return (
            <>
                <div className="region-item-body my-4" onClick={handleClick}>
                    <div className="d-flex justify-content-between">
                        <h5 style={{ color: RegionColors[data.regionCode] }}  >
                            <b><Translation tid={data.regionCode} /> </b>
                        </h5>
                        <div>
                            <b>{data.confirmed.toLocaleString(undefined, { maximumFractionDigits: 0 })}</b>
                        </div>

                    </div>
                    <div className="d-flex justify-content-between">
                        <div></div>
                        &nbsp;
                        <small style={{ fontSize: 10 }}>
                            <Translation tid="Confirmed" />
                        </small >
                    </div>
                    <bt.ProgressBar variant={data.regionCode.toLocaleLowerCase()} now={data.confirmed == max ? 100 : (data.confirmed / max) * 100} />
                </div>
            </>
        )
    }
    else {
        const colorRandom = GetRandomBgColor();
        return (<>
            <div className="region-item-body my-4">
                <div className="d-flex justify-content-between">
                    <Placeholder as="a" animation="glow">
                        <Placeholder xs={2} bg={colorRandom} size="sm" />
                    </Placeholder>
                    <div><b>
                        <Placeholder as="a" animation="glow">
                            <Placeholder xs={2} bg={colorRandom} size="sm" />
                        </Placeholder>
                    </b>
                    </div>

                </div>
                <div className="d-flex justify-content-between">
                    <div></div>
                    &nbsp;
                    <small style={{ fontSize: 10 }}>
                        <Placeholder as="a" animation="glow">
                            <Placeholder xs={7} bg={colorRandom} size="xs" />
                        </Placeholder>
                    </small >
                </div>
                <Placeholder as="a" animation="glow">
                    <Placeholder xs={12} bg={colorRandom} size="xs" />
                </Placeholder>
            </div>

        </>)
    }
}

export default RegionItem;