import React from 'react';
import { Covid19DataByRegion } from '../../types/covid19DataByRegion';
import * as bt from 'react-bootstrap';
import Placeholder from 'react-bootstrap/Placeholder';
import { GetRandomBgColor } from '../../utils/functions';
import "./regionItem.css";
import { Translation } from '../translation';
import { RegionColors } from '../../types/colors';
import { uuid } from 'uuidv4';
type Props = {
    data?: Covid19DataByRegion;
    max: number;
    selectedItem(arg?: Covid19DataByRegion): void;
}

const RegionItem: React.FC<Props> = ({ data, max, selectedItem }) => {

    const handleClick = () => {
        // selectedItem(data)!;
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
                            <b><span className="text-warning">
                                {data.confirmed.toLocaleString(undefined, { maximumFractionDigits: 0 })} </span>
                                /
                                <span className="text-danger"> {data.deaths.toLocaleString(undefined, { maximumFractionDigits: 0 })}</span>&nbsp;
                                (<span>{((data.deaths / data.confirmed) * 100).toFixed(2)} %</span>)
                            </b>
                        </div>

                    </div>
                    <div className="d-flex justify-content-between">
                        <div></div>
                        &nbsp;
                        <small style={{ fontSize: 10 }}>
                            <Translation tid="Confirmed" /> / <Translation tid="Deaths" />
                        </small >
                    </div>
                    <bt.ProgressBar key={uuid()} variant={data.regionCode.toLocaleLowerCase()} now={data.confirmed == max ? 100 : (data.confirmed / max) * 100} />
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
                            <Placeholder xs={7} bg={colorRandom} size="sm" />
                        </Placeholder>
                    </small >
                </div>
                <Placeholder as="a" animation="glow">
                    <Placeholder xs={12} bg={colorRandom} size="sm" />
                </Placeholder>
            </div>

        </>)
    }
}

export default RegionItem;